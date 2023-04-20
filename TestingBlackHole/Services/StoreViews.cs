using BlackHole.Core;
using TestingBlackHole.DTOs;
using TestingBlackHole.Entities.GuidEntities;

namespace TestingBlackHole.Services
{
    public class StoreViews
    {
        private readonly IBHDataProvider<OrderLineG, Guid> _orderLineService;

        public StoreViews()
        {
            _orderLineService = new BHDataProvider<OrderLineG,Guid>();
        }

        //Creating a stored view with 4 Tables, OrderLines, Orders, Customers, BonusPoints
        public void CreateAndStoreView()
        {
            
            int viewIndex = _orderLineService.InnerJoin<OrderG, Guid, OrderDtoG>(x => x.OrderId, x => x.Id) //.And(x=>x.Col, z=>z.Col) if you want to join on more columns
            .WhereFirst(x=>x.BonusPointsId != Guid.Empty)                                                   // We add a filter for the First Table 'OrderLines'
            .Then()                                                                                         // Then() ends the join and you can move on the next 
                    //<FirstTable,SecondTable,JoinKeyType,Dto>  Dto must be the same in all Joins. it won't be allowed to change.
            .InnerJoinOn<OrderG, CustomerG, Guid, OrderDtoG>(y => y.CustomerId, x => x.Id)
            .CastColumnOfFirstAs(x => x.Id, x => x.Id)              //Cast has priority over normal mapping, here we map the Id column of the Dto to the Id of the Orders
            .WhereSecond(x => x.UserTypeId != Guid.Empty)           // A filter for the Second Table of this Join which is Customers.
                                                                    // 'WhereFirst' can be used for the First Table of this Join
            .Then()                                                 // next action or Join
            .InnerJoinOn<OrderLineG, BonusPointsG, Guid, OrderDtoG>(x => x.BonusPointsId, z => z.Id)
            //The First Table of A Join must exist in a previous Join, Otherwise the whole Join and its parameters will be ignored in execution

            .CastColumnOfSecondAs(x => x.Points, d => d.BonusP) //We Cast a Column of the Second Table of this Join, to a Column on the Dto
            .Then()                                             // next action or Join
            .StoreAsView();                                     //We store this Join as view and we can access it later with the 'IBlackHoleViewStorage' interface
                                                                //If StoreAsView is successful it returns the index of the View in the stored views list.

            // The Join is stored with the Dto as Identifier, if you store another Join with the same Dto , this Join will be replaced by the new one.
            // If you need to store the same Join again with different parameters, you must create another identical Dto.
        }       
    }
}
