using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class FeedbackBusinessLayer
    {
        private FeedbackDataAccess _FeedbackDataAccess { get; set; }

        public FeedbackBusinessLayer()
        {
            _FeedbackDataAccess = new FeedbackDataAccess();
        }

        // write your own business logic
        
        public List<Feedback> feedback()
        {
            try
            {
                return _FeedbackDataAccess.Feedback();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Feedback> feedbackend()
        {
            try
            {
                return _FeedbackDataAccess.Feedbackend();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int savefeedback(string name,string lname, string address, string comment, string city,string state,string country,string filename,int UserID)
        {
            try
            {
                return _FeedbackDataAccess.SaveFeedback(name,lname,address,comment,city, state, country,filename, UserID);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public List<Feedback> FeedbackAdmin(int id,int del)
        {
            try
            {
                return _FeedbackDataAccess.FeedbackAdmin(id,del);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Feedback> SearchFeedbackAdmin(DateTime frmdate,DateTime todate)
        {
            try
            {
                return _FeedbackDataAccess.SearchFeedbackAdmin(frmdate,todate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int deletefeedback(int id )
        {
            try
            {
                return _FeedbackDataAccess.DeleteFeedback(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
