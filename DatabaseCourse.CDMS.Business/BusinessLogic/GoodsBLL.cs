using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class GoodsBll
    {
        #region Variables

        private CurrentUser _currentUser = null;


        #endregion

        #region Ctor

        public GoodsBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }


        #endregion

        #region Methods



        #endregion

        #region Helper
        public Goods ConvertToDataAccessModel(GoodsInfo businessModel)
        {
            if (businessModel == null) return null;
            return new Goods()
            {
                Id = businessModel.Id,
                Amount = businessModel.Amount,
                Description = businessModel.Description,
                Module = businessModel.Module,
                Name = businessModel.Name,
                Price = businessModel.Price
            };
        }

        public GoodsInfo ConvertToBusinessModel(Goods dataAccessModel)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
