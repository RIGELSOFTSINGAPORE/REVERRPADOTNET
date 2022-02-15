using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class SearchVastuBusinessLayer
    {
        private SearchVastuDataAccess _SearchVastuDataAccess { get; set; }

        public SearchVastuBusinessLayer()
        {
            _SearchVastuDataAccess = new SearchVastuDataAccess();
        }

        // write your own business logic
        public List<TypeVasthu> Type()
        {
            try
            {
                return _SearchVastuDataAccess.Type();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public List<AreaVasthu> Area()
        {
            try
            {
                return _SearchVastuDataAccess.Area();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public List<DirctionVasthu> Direction()
        {
            try
            {
                return _SearchVastuDataAccess.Direction();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        

        public List<Vasthumst> GetValues(int aidvalue, int didvalue)
        {
            try
            {
                return _SearchVastuDataAccess.Getvalues(aidvalue, didvalue);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
