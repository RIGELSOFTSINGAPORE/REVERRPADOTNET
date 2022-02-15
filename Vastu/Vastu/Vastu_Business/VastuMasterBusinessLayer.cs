﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    public class VastuMasterBusinessLayer
    {
        private VastuMasterDataAccess _VastuMasterDataAccess { get; set; }
        public VastuMasterBusinessLayer()
        {
            _VastuMasterDataAccess = new VastuMasterDataAccess();
        }

        public List<VS_VASTU_MST> GetAllVastu()
        {
            List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
            try
            {



                obj = _VastuMasterDataAccess.GetAllVastu();


            }
            catch (Exception ex)
            {
                throw ex;
                

            }
            return obj;
        }
        public List<VS_VASTU_MST> GetAllVastu(int area)
        {
            List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
            try
            {



                obj = _VastuMasterDataAccess.GetAllVastu(area);


            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }
        public List<VS_VASTU_TYPE_MST> GetAllVastuTypeList()
        {
            List<VS_VASTU_TYPE_MST> obj = new List<VS_VASTU_TYPE_MST>();
            try
            {



                obj = _VastuMasterDataAccess.GetAllVastuTypeList();


            }
            catch (Exception ex)
            {
                throw ex;
          
            }
            return obj;
        }

        public List<VS_AREA_MST> GetAllAreaList()
        {
            List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
            try
            {



                obj = _VastuMasterDataAccess.GetAllAreaList();


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }
        public List<VS_DIRECTION_MST> GetAllDirectionList()
        {
            List<VS_DIRECTION_MST> obj = new List<VS_DIRECTION_MST>();
            try
            {



                obj = _VastuMasterDataAccess.GetAllDirectionList();


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public List<VS_SCORE_MST> GetAllScoreList()
        {
            List<VS_SCORE_MST> obj = new List<VS_SCORE_MST>();
            try
            {



                obj = _VastuMasterDataAccess.GetAllScoreList();


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }
        public VS_VASTU_MST GetVastuByID(int vastuID)
        {
            VS_VASTU_MST obj = new VS_VASTU_MST();
            try
            {


                obj = _VastuMasterDataAccess.GetVastuByID(vastuID);

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            return obj;


        }

        public int CreateVastu(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {
                List<VS_VASTU_MST> imgmst = new List<VS_VASTU_MST>();

                imgmst = _VastuMasterDataAccess.CheckVastuDetail(vastumst.VASTU_TYPE_ID, vastumst.AREA_ID, vastumst.DIRECTION_ID, 0);

                if (imgmst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _VastuMasterDataAccess.CreateVastu(vastumst);
            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return result;
        }

        public int UpdateVastu(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {
                List<VS_VASTU_MST> imgmst = new List<VS_VASTU_MST>();

                imgmst = _VastuMasterDataAccess.CheckVastuDetail(vastumst.VASTU_TYPE_ID, vastumst.AREA_ID, vastumst.DIRECTION_ID, vastumst.VASTU_ID);

                if (imgmst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _VastuMasterDataAccess.UpdateVastu(vastumst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int DeleteVastu(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteVastuMaster(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteArea(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteAreaMaster(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteVastuType(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteVastuType(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteScoreMaster(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteScoreMaster(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteImageMaster(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteImageMaster(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteUserMaster(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteUserMaster(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteDirectionMaster(int VastuID)
        {
            try
            {
                return _VastuMasterDataAccess.DeleteDirectionMaster(VastuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<AreaVasthu> Area()
        {
            try
            {
                return _VastuMasterDataAccess.Area();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
