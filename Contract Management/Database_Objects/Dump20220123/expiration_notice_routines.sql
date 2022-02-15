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
-- Dumping routines for database 'expiration_notice'
--
/*!50003 DROP PROCEDURE IF EXISTS `Q30_Contracttobeterminated` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Q30_Contracttobeterminated`()
BEGIN
	SELECT  t20_contract_management.ID, t20_contract_management.Control_number, 
	t20_contract_management.Old_number,
	 DATE(t20_contract_management.Contract_date) Contract_date, 
	DATE(t20_contract_management.Contract_period_starts) Contract_period_starts, 
	DATE(t20_contract_management.Scheduled_end_date_of_contract_period) Scheduled_end_date_of_contract_period,
	 DATE(t20_contract_management.End_date) End_date, 
	t20_contract_management.Update_code, t20_contract_management.Automatic_update_interval, 
	t20_contract_management.Account_name_all, 
	t20_contract_management.Contract_name, t20_contract_management.Department_number, 
	tm15_department_master.Management_department, 
	t20_contract_management.Contractor,
	 t20_contract_management.remarks, t20_contract_management.Delete T20Delete, 
	 tm15_department_master.Delete T15Delete
	FROM tm15_department_master RIGHT JOIN t20_contract_management 
	ON tm15_department_master.Department_number = t20_contract_management.Department_number
	WHERE (((t20_contract_management.Scheduled_end_date_of_contract_period) 
	Between (CURDATE() + INTERVAL 1 DAY) And (DATE_FORMAT(CURDATE() + INTERVAL 3 month,'%Y-%m-01')- INTERVAL 1 DAY)) 
	AND ((t20_contract_management.Update_code)="0") AND ((t20_contract_management.Delete)=False) 
	AND ((tm15_department_master.Delete) Is Null Or (tm15_department_master.Delete)=False)) ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Q30_ExpectedTerminationContract_ForTesting` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Q30_ExpectedTerminationContract_ForTesting`()
BEGIN
SELECT t20_contract_management.ID, t20_contract_management.Control_number, 
t20_contract_management.Old_number, 
t20_contract_management.Contract_date, t20_contract_management.Contract_period_starts,
 t20_contract_management.Scheduled_end_date_of_contract_period, 
 t20_contract_management.End_date,
 t20_contract_management.Update_code,
 t20_contract_management.Automatic_update_interval,
 t20_contract_management.Account_name_all, t20_contract_management.Contract_name, 
 tm15_department_master.Management_department, 
 t20_contract_management.Contractor, 
 t20_contract_management.remarks, t20_contract_management.Delete T20Delete,
 tm15_department_master.Delete T15Delete
FROM tm15_department_master 
RIGHT JOIN t20_contract_management 
ON tm15_department_master.Department_number = t20_contract_management.Department_number
WHERE (((t20_contract_management.Scheduled_end_date_of_contract_period) Between (CURDATE() + INTERVAL 1 DAY) And 
(DATE_FORMAT((CURDATE() + INTERVAL 3 month) + INTERVAL 1 year,'%Y-%m-01') - INTERVAL 1 DAY))
AND ((t20_contract_management.Update_code)="0") AND ((t20_contract_management.Delete)=False) 
AND ((tm15_department_master.Delete) Is Null Or (tm15_department_master.Delete)=False));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Q30_Scheduled_termination_contract_date_specification` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Q30_Scheduled_termination_contract_date_specification`(IN expdate VARCHAR(255))
BEGIN
SELECT t20_contract_management.ID, t20_contract_management.Control_number, 
t20_contract_management.Old_number, 
t20_contract_management.Contract_date, t20_contract_management.Contract_period_starts,
 t20_contract_management.Scheduled_end_date_of_contract_period, 
 t20_contract_management.End_date,
 t20_contract_management.Update_code,
 t20_contract_management.Automatic_update_interval,
 t20_contract_management.Account_name_all, t20_contract_management.Contract_name, 
 tm15_department_master.Management_department, 
 t20_contract_management.Contractor, 
 t20_contract_management.remarks, t20_contract_management.Delete T20Delete,
 tm15_department_master.Delete T15Delete
FROM tm15_department_master 
RIGHT JOIN t20_contract_management 
ON tm15_department_master.Department_number = t20_contract_management.Department_number
WHERE (((t20_contract_management.Scheduled_end_date_of_contract_period) 
	Between current_date() And expdate) AND ((t20_contract_management.Update_code)='0') 
	AND ((t20_contract_management.Delete)=False) AND ((tm15_department_master.Delete) Is Null Or (tm15_department_master.Delete)=False));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Q30_Survey_Date_Report` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Q30_Survey_Date_Report`(IN surStdate VARCHAR(255),IN surEddate VARCHAR(255))
BEGIN
SELECT t20_contract_management.ID, t20_contract_management.Control_number, 
t20_contract_management.Old_number, 
t20_contract_management.Contract_date, t20_contract_management.Contract_period_starts,
 t20_contract_management.Scheduled_end_date_of_contract_period, 
 t20_contract_management.End_date,
 t20_contract_management.Survey_Date,
 t20_contract_management.Update_code,
 t20_contract_management.Automatic_update_interval,
 t20_contract_management.Account_name_all, t20_contract_management.Contract_name, 
 tm15_department_master.Management_department, 
 t20_contract_management.Contractor, 
 t20_contract_management.remarks, t20_contract_management.Delete T20Delete,
 tm15_department_master.Delete T15Delete
FROM tm15_department_master 
RIGHT JOIN t20_contract_management 
ON tm15_department_master.Department_number = t20_contract_management.Department_number
WHERE (((t20_contract_management.Survey_Date) 
	Between surStdate And surEddate) AND ((t20_contract_management.Update_code)='0') 
	AND ((t20_contract_management.Delete)=False) AND ((tm15_department_master.Delete) Is Null Or (tm15_department_master.Delete)=False));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-23 19:50:39
