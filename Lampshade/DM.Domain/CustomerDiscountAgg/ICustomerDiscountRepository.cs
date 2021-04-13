using _0_Framework.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long , CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountsViewModel> Search(CustomerDiscountSearchModel searchModel);

    }
}
