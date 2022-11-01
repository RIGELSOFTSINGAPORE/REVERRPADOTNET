using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennaMiddleWare.Models
{
    //yrealization Report
    public class ZSD_REAL_DATA_SRV_REAL
    {
        //public Response[] response { get; set; }
        public string Vbeln { get; set; }
        public string Vgbel { get; set; }
        public string Aubel { get; set; }
        public string Erdat { get; set; }
        public string Fkart { get; set; }
        public string Regio { get; set; }
        public string Vkgrp { get; set; }
        public string Dstrc { get; set; }
        public string Mnfplant { get; set; }
        public string Plant { get; set; }
        public string Grade { get; set; }
        public string Matkl { get; set; }
        public string Kalks { get; set; }
        public string Kdgrp { get; set; }
        public string Fkdat { get; set; }
        public string Matnr { get; set; }
        public string Custcode1 { get; set; }
        public string Cname1 { get; set; }
        public string Custcode2 { get; set; }
        public string Cname2 { get; set; }
        public string Custcode3 { get; set; }
        public string Cname3 { get; set; }
        public string ComAg { get; set; }
        public string ComName { get; set; }
        public string Trans { get; set; }
        public string TransName { get; set; }
        public string Lgort { get; set; }
        public string Lgobe { get; set; }
        public decimal Fkimg { get; set; }
        public decimal Grossturn { get; set; }
        public string Inco1 { get; set; }
        public string Inco2 { get; set; }
        public decimal Stprs { get; set; }
        public decimal Primaryfri { get; set; }
        public decimal Secondaryfri { get; set; }
        public decimal Exwpf { get; set; }
        public decimal Exgsf { get; set; }
        public decimal Salestax { get; set; }
        public decimal Commission { get; set; }
        public decimal Exciseduty { get; set; }
        public decimal Pddiscount { get; set; }
        public decimal Oddiscount { get; set; }
        public decimal Cfcharges { get; set; }
        public decimal Cddiscount { get; set; }
        public decimal Packing { get; set; }
        public decimal Unloading { get; set; }
        public decimal Octrai { get; set; }
        public decimal Vat { get; set; }
        public decimal Igst { get; set; }
        public decimal Cgst { get; set; }
        public decimal Sgst { get; set; }
        public decimal Ugst { get; set; }
        public decimal ExpHand { get; set; }
        public decimal Transport { get; set; }
        public decimal AmtDwFrt { get; set; }
        public decimal PltFrt { get; set; }
        public decimal Netturn { get; set; }
        public decimal Nakedreal { get; set; }
        public string Statedesc { get; set; }
        public string Sgrpdesc { get; set; }
        public string Disdesc { get; set; }
        public string Graddesc { get; set; }
        public string Mnfdesc { get; set; }
        public string Plantdesc { get; set; }
        public string Pgrpdesc { get; set; }
        public string Cdate { get; set; }
        public string Time { get; set; }
        public string Suser { get; set; }
        public string BlockCt { get; set; }
        public string Route { get; set; }
        public string Canceldate { get; set; }
        public string Cancelflag { get; set; }
        public string Zzlgort1 { get; set; }
        public string Bzirk { get; set; }
        public string Vkbur { get; set; }
        public string Zzzone1 { get; set; }
        public string Zzbranch { get; set; }
        public string PernrEr { get; set; }
        public string EnameEr { get; set; }
        public string PernrY1 { get; set; }
        public string EnameY1 { get; set; }
        public string PernrY2 { get; set; }
        public string EnameY2 { get; set; }
        public string PernrY3 { get; set; }
        public string EnameY3 { get; set; }
        public string PernrY4 { get; set; }
        public string EnameY4 { get; set; }
        public string PernrY5 { get; set; }
        public string EnameY5 { get; set; }
        public string PernrY6 { get; set; }
        public string EnameY6 { get; set; }
        public string PernrY7 { get; set; }
        public string EnameY7 { get; set; }
        public string PernrY8 { get; set; }
        public string EnameY8 { get; set; }
        public decimal UpfrntDiscount { get; set; }
        public decimal IndPriFrt { get; set; }
        public decimal ShipFrtChrgs { get; set; }
        public decimal ShipHandChrgs { get; set; }
        public string ZcustGrp { get; set; }
        public string ZcustGrpDesc { get; set; }
        public decimal Vc { get; set; }
        public decimal ZsalePromValue { get; set; }
        public string Waers { get; set; }
        public string Msehi { get; set; }
        public decimal PayFreight { get; set; }
        public decimal ExFreight { get; set; }
    }

    public class SearchSRVREAL
    {
        public string startDate { get; set; }
        public string endDate { get; set; }

        public string GroupID { get; set; }
    }

    //Logi Cost Report

    public class ZSD_LCOST_DATA_SRV
    {
        public string Vbeln { get; set; }
        public string Fkart { get; set; }
        public string Fkdat { get; set; }
        public decimal Fkimg { get; set; }
        public string Meins { get; set; }
        public string Werks { get; set; }
        public string WName1 { get; set; }
        public string Zsource { get; set; }
        public string Zsourced { get; set; }
        public string Ztratyp { get; set; }
        public string Ztratypd { get; set; }
        public string Kunnr { get; set; }
        public string KunnrN { get; set; }
        public string Kunag { get; set; }
        public string KunagN { get; set; }
        public string Ptnr { get; set; }
        public string PtnrN { get; set; }
        public string Salsrep { get; set; }
        public string SalsrepN { get; set; }
        public string Regio { get; set; }
        public string RegioN { get; set; }
        public string Dstrc { get; set; }
        public string DstrcN { get; set; }
        public string Block { get; set; }
        public string BlockN { get; set; }
        public string Destint { get; set; }
        public string DestintN { get; set; }
        public string Kdgrp { get; set; }
        public string Ktext { get; set; }
        public decimal PrimaryFrt { get; set; }
        public decimal SecondryFrt { get; set; }
        public string Rakno { get; set; }
        public string Rakpt { get; set; }
        public string Matkl { get; set; }
        public string Lgort { get; set; }
        public string Lgobe { get; set; }
        public string Inco1 { get; set; }
        public string Inco2 { get; set; }
        public decimal UldgChgs { get; set; }
        public decimal TrnsChgs { get; set; }
        public decimal DpulChgs { get; set; }
        public decimal DpldChgs { get; set; }
        public decimal DivrChgs { get; set; }
        public decimal LdngChgs { get; set; }
        public decimal CfagChgs { get; set; }
        public decimal RksrChgs { get; set; }
        public decimal PuldChgs { get; set; }
        public decimal RkclChgs { get; set; }
        public decimal ShntChgs { get; set; }
        public decimal RkcfChgs { get; set; }
        public decimal BlndChgs { get; set; }
        public decimal BlnbChgs { get; set; }
        public decimal MiscMisc { get; set; }
        public string Zzzone1 { get; set; }
        public string Zzzone1N { get; set; }
        public string Zzbzirk { get; set; }
        public string ZzbzirkN { get; set; }
        public string Zzregio { get; set; }
        public string ZzregioN { get; set; }
        public string Vkbur { get; set; }
        public string VkburN { get; set; }
        public string Vkgrp { get; set; }
        public string VkgrpN { get; set; }
        public string Zzbranch { get; set; }
        public string ZzbranchN { get; set; }
        public decimal Pdstn { get; set; }
        public decimal Sdstn { get; set; }
        public string BlockCt { get; set; }
        public string Belnr { get; set; }
        public string Gjahr { get; set; }
        public string InvType { get; set; }
        public string FrtType { get; set; }
        public string Zzvlfkz { get; set; }
        public string SuppPlantName { get; set; }
        public string DepoRkMvt { get; set; }
        public decimal IndPriFrt { get; set; }
        public decimal ShipFrtChrgs { get; set; }
        public decimal ShipHandChrgs { get; set; }
        public string Clkmnfplant { get; set; }
        public string Suppplant { get; set; }
        public decimal Distance { get; set; }
        public decimal Indpdistance { get; set; }
        public string ClkPltName { get; set; }
        public string MnfPltName { get; set; }
        public string GeindPlt { get; set; }
        public string GeindPltName { get; set; }
        public string SupplDepo { get; set; }
        public string SupplDepoName { get; set; }
        public string Waerk { get; set; }
        public decimal Rent { get; set; }
        public decimal Rakedemchrg { get; set; }
        public decimal Ldistance { get; set; }
        public decimal LdistanceClk { get; set; }
        public string Matnr { get; set; }
        public string Vtext { get; set; }
        public string Matnr1 { get; set; }
        public string Maktx { get; set; }
        public decimal Incurredcost { get; set; }
        public decimal Unincurredcost { get; set; }
        public string ShRegio { get; set; }
        public string ShDstrc { get; set; }
        public string ShBlock { get; set; }
        public string ShDestint { get; set; }
        public string Kalks { get; set; }
        public string DeliveryNo { get; set; }
        public string Tknum { get; set; }
        public string Mnfplant { get; set; }
        public string Mnfdesc { get; set; }
        public string Mvgr1 { get; set; }
        public decimal Grossturn { get; set; }
        public decimal Netturn { get; set; }
        public decimal Nakedreal { get; set; }
        public decimal TransIncentive { get; set; }
        public decimal PltFrt { get; set; }
        public string SpRegio { get; set; }
        public string SpDstrc { get; set; }
        public string SpBlock { get; set; }
        public string SpDestint { get; set; }
        public string Traid { get; set; }
        public string TruckType { get; set; }
        public string EwbNo { get; set; }
        public string Edate { get; set; }
        public string Evdate { get; set; }
        public string Steuc { get; set; }
        public decimal PaidPrice { get; set; }
        public string KalksDesc { get; set; }
        public string SpRegioDesc { get; set; }
        public string SpDstrcDesc { get; set; }
        public string SpBlockDesc { get; set; }
        public string SpDestintDesc { get; set; }
        public string MfPlantType { get; set; }
        public decimal TotalTdcCost { get; set; }
        public decimal TotalDistance { get; set; }
        public decimal DepotIndFrieght { get; set; }
        public decimal TotalInvoiceFrt { get; set; }
        public decimal RoadPfIncurred { get; set; }
        public decimal RoadPfUnincurred { get; set; }
        public decimal RoadSfIncurred { get; set; }
        public decimal RoadSfUnincurred { get; set; }
        public decimal RailPfIncurred { get; set; }
        public decimal RailPfUnincurred { get; set; }
        public decimal DrdlChgs { get; set; }
        public decimal DbLabChgs { get; set; }
        public string ZinvCancel { get; set; }
        public string ShDestintDesc { get; set; }
        public decimal ShipDistance { get; set; }

    }

    public class Schdates
    {
        public int RowNo { get; set; }
        public string startdate { get; set; }

        public string enddate { get; set; }
    }

    public class ZFI_AGEING_OD_SRV
    {
        public string Bukrs { get; set; }
        public string Budat { get; set; }
        public string Kunnr { get; set; }
        public string Ktokd { get; set; }
        public string Name1 { get; set; }
        public string Kunn2 { get; set; }
        public string Name2 { get; set; }
        public string Kunn3 { get; set; }
        public string Name3 { get; set; }
        public decimal Slab1 { get; set; }
        public decimal Slab2 { get; set; }
        public decimal Slab3 { get; set; }
        public decimal Slab4 { get; set; }
        public decimal Slab5 { get; set; }
        public decimal Slab6 { get; set; }
        public decimal Slab7 { get; set; }
        public decimal Slab8 { get; set; }
        public decimal Slab9 { get; set; }
        public string Waers { get; set; }
        public string Regio { get; set; }
        public string Dstrc { get; set; }
        public string Dstxt { get; set; }
        public string Regtxt { get; set; }
        public string Zzzone { get; set; }
        public string Zzbranch { get; set; }
        public string Vkorg { get; set; }
        public string Vkgrp { get; set; }
        public string Vkbur { get; set; }
        public string Zzbzirk { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableCl { get; set; }
        public string CreditPeriod { get; set; }
        public string OsDays { get; set; }
        public decimal OsAmt { get; set; }
        public decimal OsOdAmt { get; set; }
        public string OsOdDays { get; set; }
        public decimal SecurityDep { get; set; }
        public decimal ChqnrAmt { get; set; }
        public decimal CurrFyOdOs { get; set; }
        public decimal PreFyOdOs { get; set; }
        public decimal PreFyClsOdOs { get; set; }
        public decimal ActualOd { get; set; }

    }

    public class ZSD_MRP_PRINTING_SRV
    {
        public string Plant { get; set; }
        public string Vbeln { get; set; }
        public string Bags { get; set; }
        public string Traid { get; set; }
        public string Vtext { get; set; }
        public string Mrp { get; set; }
        

    }


    public class ZSD_COLLN_SRV
    {
        public string BillDate { get; set; }
        public string Depart { get; set; }
        public string Sno { get; set; }
        public string Regio { get; set; }
        public string DayTagt { get; set; }
        public string DayActls { get; set; }
        public string DayDif { get; set; }
        public string MTar { get; set; }
        public string MtdTar { get; set; }
        public string MtdAct { get; set; }
        public string DishonrsAmt { get; set; }
        public string Cnt { get; set; }
        public string ActInBank { get; set; }
        public string MtdDiff { get; set; }
        public string Achvd { get; set; }
        public string TotParMon { get; set; }
        public string TotParDat { get; set; }
        public string TotParRem { get; set; }

    }

    public class ZSD_MW_SALES_SRV
    {
        public string BillDate { get; set; }
        public string Depart { get; set; }
        public string Sno { get; set; }
        public string Regio { get; set; }
        public string DayTagt { get; set; }
        public string DayActls { get; set; }
        public string DayDif { get; set; }
        public string MTar { get; set; }
        public string MtdTar { get; set; }
        public string MtdAct { get; set; }
        public string MtdDiff { get; set; }
        public string Achd { get; set; }
        public string Opc { get; set; }
        public string Blnd { get; set; }
        public string Tr { get; set; }
        public string Ntr { get; set; }
        public string Dtr { get; set; }
        public string Dntr { get; set; }
        public string PrRerata { get; set; }
        public string PltrOndate { get; set; }
        public string PltrMondate { get; set; }

    }
    public class ZSD_MW_SALES_DIS_SRV
    {
        public string BillDate { get; set; }
        public string Depart { get; set; }
        public string Sno { get; set; }
        public string Regio { get; set; }
        public string DayTagt { get; set; }
        public string DayActls { get; set; }
        public string DayDif { get; set; }
        public string MTar { get; set; }
        public string MtdTar { get; set; }
        public string MtdAct { get; set; }
        public string MtdDiff { get; set; }
        public string Achd { get; set; }
        public string Opc { get; set; }
        public string Blnd { get; set; }
        public string ProRata { get; set; }
        public string PrRrata { get; set; }
        public string PrRerata { get; set; }
        public string PltrOndate { get; set; }
        public string PltrMondate { get; set; }

    }

    public class ZSD_MW_REALISATION_SRV
    {
        public string BillDate { get; set; }
        public string Depart { get; set; }
        public string Sno { get; set; }
        public string Statedesc { get; set; }
        public string TNetper { get; set; }
        public string TPerton { get; set; }
        public string NNetper { get; set; }
        public string NPerton { get; set; }
        public string TotNetper { get; set; }
        public string TotPerton { get; set; }
        public string MtNetper { get; set; }
        public string MtPerton { get; set; }
        public string MnNetper { get; set; }
        public string MnPerton { get; set; }
        public string MtotPerton { get; set; }
        public string MtotNetper { get; set; }
        public string Regio { get; set; }

    }

    public class ZFI_MW_STATEWISE_OD_SRV
    {


        public String CreationDate { get; set; }
        public String Regio { get; set; }
        public String Ktokd { get; set; }
        public Decimal TotalOs { get; set; }
        public Decimal TotalOverdue { get; set; }
        public Decimal TotalChqnrAmt { get; set; }
        public Decimal CurrFyOdOs { get; set; }
        public Decimal PreFyOdOs { get; set; }
        public Decimal PreFyClsOdOs { get; set; }

    }
}