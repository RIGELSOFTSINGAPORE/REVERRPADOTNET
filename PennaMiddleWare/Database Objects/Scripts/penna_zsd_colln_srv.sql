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
-- Table structure for table `zsd_colln_srv`
--

DROP TABLE IF EXISTS `zsd_colln_srv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zsd_colln_srv` (
  `ZSD_COLLN_SRV_PKID` int NOT NULL AUTO_INCREMENT,
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
  `DishonrsAmt` varchar(13) NOT NULL,
  `Cnt` varchar(10) NOT NULL,
  `ActInBank` varchar(10) NOT NULL,
  `MtdDiff` varchar(13) NOT NULL,
  `Achvd` varchar(10) NOT NULL,
  `TotParMon` varchar(10) NOT NULL,
  `TotParDat` varchar(10) NOT NULL,
  `TotParRem` varchar(10) NOT NULL,
  PRIMARY KEY (`ZSD_COLLN_SRV_PKID`)
) ENGINE=InnoDB AUTO_INCREMENT=5137751 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
