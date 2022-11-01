-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: penna
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `zsd_mw_sales_srv`
--

DROP TABLE IF EXISTS `zsd_mw_sales_srv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zsd_mw_sales_srv` (
  `zsd_mw_sales_srv_pkid` bigint NOT NULL AUTO_INCREMENT,
  `BillDate` varchar(10) NOT NULL,
  `Depart` varchar(1) NOT NULL,
  `Sno` varchar(3) NOT NULL,
  `Regio` varchar(36) NOT NULL,
  `DayTagt` varchar(13) NOT NULL,
  `DayActls` varchar(13) NOT NULL,
  `DayDif` varchar(13) NOT NULL,
  `MTar` varchar(13) NOT NULL,
  `MtdTar` varchar(13) NOT NULL,
  `MtdAct` varchar(13) NOT NULL,
  `MtdDiff` varchar(13) NOT NULL,
  `Achd` varchar(13) NOT NULL,
  `Opc` varchar(13) NOT NULL,
  `Blnd` varchar(13) NOT NULL,
  `Tr` varchar(13) NOT NULL,
  `Ntr` varchar(13) NOT NULL,
  `Dtr` varchar(13) NOT NULL,
  `Dntr` varchar(13) NOT NULL,
  `PrRerata` varchar(13) NOT NULL,
  `PltrOndate` varchar(13) NOT NULL,
  `PltrMondate` varchar(13) NOT NULL,
  PRIMARY KEY (`zsd_mw_sales_srv_pkid`)
) ENGINE=InnoDB AUTO_INCREMENT=96 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-31 12:47:03
