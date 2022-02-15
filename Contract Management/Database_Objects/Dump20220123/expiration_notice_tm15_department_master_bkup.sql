-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: expiration_notice
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `tm15_department_master_bkup`
--

DROP TABLE IF EXISTS `tm15_department_master_bkup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tm15_department_master_bkup` (
  `ID` int DEFAULT NULL,
  `Department_number` smallint DEFAULT NULL,
  `Management_department` varchar(255) DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  `Delete` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tm15_department_master_bkup`
--

LOCK TABLES `tm15_department_master_bkup` WRITE;
/*!40000 ALTER TABLE `tm15_department_master_bkup` DISABLE KEYS */;
INSERT INTO `tm15_department_master_bkup` VALUES (1,0,'-',NULL,_binary '\0'),(2,1,'BSL',NULL,_binary '\0'),(3,2,'東京センター',NULL,_binary '\0'),(4,3,'大阪センター','旧：ＦＳ',_binary '\0'),(5,4,'名古屋',NULL,_binary '\0'),(6,5,'秋葉原',NULL,_binary '\0'),(7,6,'ESS',NULL,_binary '\0'),(8,7,'京都',NULL,_binary '\0'),(9,8,'日本橋',NULL,_binary '\0'),(10,9,'HR',NULL,_binary '\0'),(11,10,'HUB',NULL,_binary '\0'),(12,11,'iQG',NULL,_binary '\0'),(13,12,'海老名CRC',NULL,_binary '\0'),(14,13,'N-CRC',NULL,_binary '\0'),(15,14,'梅田','旧：RS',_binary '\0'),(16,15,'新浦安',NULL,_binary '\0'),(17,16,'東京駅前丸の内',NULL,_binary '\0'),(18,17,'大宮',NULL,_binary '\0'),(19,18,'QG',NULL,_binary '\0'),(20,19,'業務支援','旧：QGHQ',_binary '\0'),(21,20,'QGS',NULL,_binary '\0'),(22,21,'立川',NULL,_binary '\0'),(23,22,'神戸三宮',NULL,_binary '\0'),(24,23,'四条烏山',NULL,_binary '\0'),(25,24,'ららぽーと横浜',NULL,_binary '\0'),(26,25,'QGSL（文教）',NULL,_binary '\0'),(27,26,'五反田TOC',NULL,_binary '\0'),(28,27,'OTS',NULL,_binary '\0'),(29,28,'iQGHQ',NULL,_binary '\0'),(30,29,'広島',NULL,_binary '\0'),(31,30,'海老名',NULL,_binary '\0'),(32,31,'大阪センター堺出張所',NULL,_binary '\0'),(33,32,'QGコールセンター',NULL,_binary '\0'),(34,33,'戦略アライアンス',NULL,_binary '\0'),(35,34,'その他契約',NULL,_binary '\0'),(36,35,'渋谷',NULL,_binary '\0'),(37,36,'BSS',NULL,_binary '\0'),(38,37,'CS',NULL,_binary '\0'),(39,38,'GSS',NULL,_binary '\0'),(40,39,'HQ',NULL,_binary '\0'),(41,40,'幕張',NULL,_binary '\0'),(42,41,'iQGS','旧：QGHQ',_binary '\0'),(43,42,'LMS',NULL,_binary '\0'),(44,43,'MBS',NULL,_binary '\0'),(45,44,'MSS',NULL,_binary '\0'),(46,45,'NWS',NULL,_binary '\0'),(47,46,'QS',NULL,_binary '\0'),(48,47,'SMG',NULL,_binary '\0'),(49,48,'SS',NULL,_binary '\0'),(50,49,'SB',NULL,_binary '\0'),(51,52,'HW大阪',NULL,_binary '\0'),(52,53,'TSF',NULL,_binary '\0'),(53,55,'SRC',NULL,_binary '\0'),(54,57,'HW銀座',NULL,_binary '\0'),(55,58,'HW五反田',NULL,_binary '\0'),(56,59,'ＳＭＤ','旧：営業統括部、ESS',_binary '\0'),(57,70,'DEV','旧：システムサポート室',_binary '\0'),(58,90,'管理本部',NULL,_binary '\0'),(59,99,'プロセスマネジメント GSS India Support Desk',NULL,_binary '\0');
/*!40000 ALTER TABLE `tm15_department_master_bkup` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-23 19:50:38
