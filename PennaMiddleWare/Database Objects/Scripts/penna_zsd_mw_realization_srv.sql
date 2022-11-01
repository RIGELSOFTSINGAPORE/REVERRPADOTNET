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
-- Table structure for table `zsd_mw_realization_srv`
--

DROP TABLE IF EXISTS `zsd_mw_realization_srv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zsd_mw_realization_srv` (
  `zsd_mw_realization_srv_pkid` bigint NOT NULL AUTO_INCREMENT,
  `BillDate` varchar(10) NOT NULL,
  `Depart` varchar(1) NOT NULL,
  `Sno` varchar(3) NOT NULL,
  `Statedesc` varchar(36) NOT NULL,
  `TNetper` varchar(13) NOT NULL,
  `TPerton` varchar(13) NOT NULL,
  `NNetper` varchar(13) NOT NULL,
  `NPerton` varchar(13) NOT NULL,
  `TotNetper` varchar(13) NOT NULL,
  `TotPerton` varchar(13) NOT NULL,
  `MtNetper` varchar(13) NOT NULL,
  `MtPerton` varchar(13) NOT NULL,
  `MnNetper` varchar(13) NOT NULL,
  `MnPerton` varchar(13) NOT NULL,
  `MtotPerton` varchar(13) NOT NULL,
  `MtotNetper` varchar(13) NOT NULL,
  `Regio` varchar(3) NOT NULL,
  PRIMARY KEY (`zsd_mw_realization_srv_pkid`)
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
