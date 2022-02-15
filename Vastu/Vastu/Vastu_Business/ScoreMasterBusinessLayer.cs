using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    
    public class ScoreMasterBusinessLayer
    {
        private ScoreMasterDataAccess _ScoreMasterDataAccess { get; set; }
        public ScoreMasterBusinessLayer()
        {
            _ScoreMasterDataAccess = new ScoreMasterDataAccess();
        }

        public List<VS_SCORE_MST> GetAllScore()
        {
            List<VS_SCORE_MST> obj = new List<VS_SCORE_MST>();
            try
            {



                obj = _ScoreMasterDataAccess.GetAllScore();


            }
            catch (Exception ex)
            {
                throw ex;
                

            }
            return obj;
        }

        public VS_SCORE_MST GetScoreByID(int scoreID)
        {
            VS_SCORE_MST obj = new VS_SCORE_MST();
            try
            {


                obj = _ScoreMasterDataAccess.GetScoreByID(scoreID);

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            return obj;


        }

        public int CreateScore(VS_SCORE_MST scoremst)
        {
            int result = 0;
            try
            {

                List<VS_SCORE_MST> scrmst = new List<VS_SCORE_MST>();

                scrmst = _ScoreMasterDataAccess.CheckScoreDetail(scoremst.SCORE, 0);

                if (scrmst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _ScoreMasterDataAccess.CreateScore(scoremst);
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return result;
        }

        public int UpdateScore(VS_SCORE_MST scoremst)
        {
            int result = 0;
            try
            {
                List<VS_SCORE_MST> scrmst = new List<VS_SCORE_MST>();

                scrmst = _ScoreMasterDataAccess.CheckScoreDetail(scoremst.SCORE, scoremst.SCORE_ID);

                if (scrmst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _ScoreMasterDataAccess.UpdateScore(scoremst);

            }
            catch (Exception ex)
            {
                throw ex;
              
            }
            return result;
        }
    }
}
