-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: modernpos_queue
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8mb4 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `b_company`
--

DROP TABLE IF EXISTS `b_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_company` (
  `comp_id` bigint(20) NOT NULL,
  `comp_code` varchar(255) DEFAULT NULL,
  `comp_name_t` varchar(255) DEFAULT NULL,
  `comp_name_e` varchar(255) DEFAULT NULL,
  `comp_address_e` varchar(50) DEFAULT NULL,
  `comp_address_t` varchar(255) DEFAULT NULL,
  `addr1` varchar(255) DEFAULT NULL,
  `addr2` varchar(255) DEFAULT NULL,
  `addr3` varchar(255) DEFAULT NULL,
  `amphur_id` varchar(255) DEFAULT NULL,
  `district_id` varchar(255) DEFAULT NULL,
  `province_id` varchar(255) DEFAULT NULL,
  `zipcode` varchar(255) DEFAULT NULL,
  `tele` varchar(255) DEFAULT NULL,
  `fax` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `website` varchar(255) DEFAULT NULL,
  `logo` varchar(255) DEFAULT NULL,
  `tax_id` varchar(255) DEFAULT NULL,
  `vat` double DEFAULT NULL,
  `spec1` varchar(255) DEFAULT NULL,
  `date_create` varchar(255) DEFAULT NULL,
  `date_modi` varchar(255) DEFAULT NULL,
  `date_cancel` varchar(255) DEFAULT NULL,
  `user_create` varchar(255) DEFAULT NULL,
  `user_modi` varchar(255) DEFAULT NULL,
  `user_cancel` varchar(255) DEFAULT NULL,
  `qu_line1` varchar(255) DEFAULT NULL,
  `qu_line2` varchar(255) DEFAULT NULL,
  `qu_line3` varchar(255) DEFAULT NULL,
  `qu_line4` varchar(255) DEFAULT NULL,
  `qu_line5` varchar(255) DEFAULT NULL,
  `qu_line6` varchar(255) DEFAULT NULL,
  `qu_due_period` varchar(255) DEFAULT NULL COMMENT 'จำนวนวันในใบเสนอราคา',
  `inv_line1` varchar(255) DEFAULT NULL,
  `inv_line2` varchar(255) DEFAULT NULL,
  `inv_line3` varchar(255) DEFAULT NULL,
  `inv_line4` varchar(255) DEFAULT NULL,
  `inv_line5` varchar(255) DEFAULT NULL,
  `inv_line6` varchar(255) DEFAULT NULL,
  `inv_due_period` varchar(255) DEFAULT NULL COMMENT 'จำนวนวันในการให้ credit',
  `rec_line1` varchar(255) DEFAULT NULL,
  `rec_line2` varchar(255) DEFAULT NULL,
  `rec_line3` varchar(255) DEFAULT NULL,
  `rec_line4` varchar(255) DEFAULT NULL,
  `rec_line5` varchar(255) DEFAULT NULL,
  `rec_line6` varchar(255) DEFAULT NULL,
  `po_line1` varchar(255) DEFAULT NULL,
  `po_line2` varchar(255) DEFAULT NULL,
  `po_line3` varchar(255) DEFAULT NULL,
  `po_line4` varchar(255) DEFAULT NULL,
  `po_line5` varchar(255) DEFAULT NULL,
  `po_line6` varchar(255) DEFAULT NULL,
  `po_due_period` varchar(255) DEFAULT NULL COMMENT 'จำนวนวันในการขอ credit',
  `active` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`comp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1000000000 DEFAULT CHARSET=utf8 COMMENT='id=100';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_company`
--

LOCK TABLES `b_company` WRITE;
/*!40000 ALTER TABLE `b_company` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_prefix`
--

DROP TABLE IF EXISTS `b_prefix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_prefix` (
  `prefix_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `prefix_code` varchar(255) DEFAULT NULL,
  `prefix_name_t` varchar(255) DEFAULT NULL,
  `prefix_name_e` varchar(255) DEFAULT NULL,
  `prefix_active` varchar(255) DEFAULT NULL,
  `status_prefix` varchar(255) DEFAULT NULL COMMENT '1=บุคคล 2= นิติบุคคล',
  PRIMARY KEY (`prefix_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1010000000 DEFAULT CHARSET=utf8 COMMENT='id=101';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_prefix`
--

LOCK TABLES `b_prefix` WRITE;
/*!40000 ALTER TABLE `b_prefix` DISABLE KEYS */;
INSERT INTO `b_prefix` VALUES (1,'001','นาย',NULL,'1','1'),(2,'002','นาง',NULL,'1','1'),(3,'003','น.ส.',NULL,'1','1'),(4,'004','นายแพทย์',NULL,'1','1');
/*!40000 ALTER TABLE `b_prefix` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_queue`
--

DROP TABLE IF EXISTS `b_queue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_queue` (
  `queue_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `queue_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'XXXX',
  `queue_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `queue_prefix` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'ตัวย่อ ชื่อย่อ',
  `queue_start` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'คิวเริ่มต้น',
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`queue_id`)
) ENGINE=MyISAM AUTO_INCREMENT=106000011 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=106';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue`
--

LOCK TABLES `b_queue` WRITE;
/*!40000 ALTER TABLE `b_queue` DISABLE KEYS */;
INSERT INTO `b_queue` VALUES (106000007,'','cccccc',NULL,NULL,'1','2021-12-29 09:49:37',NULL,NULL,'',NULL,NULL),(106000006,'','bbbbb',NULL,NULL,'1','2021-12-29 09:49:36',NULL,NULL,'',NULL,NULL),(106000005,'xxxx','aaaaa','A','5','1','2021-12-29 09:49:35','2021-12-31 07:39:28',NULL,'','',NULL),(106000008,'','dddddd',NULL,NULL,'1','2021-12-29 09:52:00',NULL,NULL,'',NULL,NULL),(106000009,'xxxx','eeeeee','E','','1','2021-12-31 07:40:00',NULL,NULL,'',NULL,NULL),(106000010,'xxxx','fffff','F','10','1','2021-12-31 07:40:21',NULL,NULL,'',NULL,NULL);
/*!40000 ALTER TABLE `b_queue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_queue_call`
--

DROP TABLE IF EXISTS `b_queue_call`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_queue_call` (
  `queue_call_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `queue_call_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `status_lock` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=lock มีคนใช้งานอยู่',
  PRIMARY KEY (`queue_call_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1070000028 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=107';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue_call`
--

LOCK TABLES `b_queue_call` WRITE;
/*!40000 ALTER TABLE `b_queue_call` DISABLE KEYS */;
INSERT INTO `b_queue_call` VALUES (1070000000,'','3','2022-01-02 11:25:02','2022-01-02 11:39:40','2022-01-02 11:39:41','','','',NULL),(1070000001,'','3','2022-01-02 11:25:02','2022-01-02 11:39:44','2022-01-02 11:39:45','','','',NULL),(1070000002,'1','1','2022-01-02 11:25:16','2022-01-02 11:54:12',NULL,'','',NULL,NULL),(1070000003,'2','1','2022-01-02 11:25:16','2022-01-02 11:54:11',NULL,'','',NULL,NULL),(1070000004,'3','1','2022-01-02 11:25:17','2022-01-02 11:53:58',NULL,'','',NULL,'1'),(1070000005,'2','3','2022-01-02 11:25:18','2022-01-02 11:39:48','2022-01-02 11:39:49','','','',NULL),(1070000006,'2','3','2022-01-02 11:25:19','2022-01-02 11:39:51','2022-01-02 11:39:52','','','',NULL),(1070000007,'1','3','2022-01-02 11:25:19','2022-01-02 11:39:54','2022-01-02 11:39:55','','','',NULL),(1070000008,'1','3','2022-01-02 11:25:45','2022-01-02 11:39:57','2022-01-02 11:39:58','','','',NULL),(1070000009,'','3','2022-01-02 11:46:26','2022-01-02 11:53:32','2022-01-02 11:53:33','','','',NULL),(1070000010,'','3','2022-01-02 11:46:39','2022-01-02 11:53:35','2022-01-02 11:53:36','','','',NULL),(1070000011,'','3','2022-01-02 11:52:09','2022-01-02 11:53:38','2022-01-02 11:53:39','','','',NULL),(1070000012,'','3','2022-01-02 11:52:19','2022-01-02 11:53:41','2022-01-02 11:53:42','','','',NULL),(1070000013,'','3','2022-01-02 11:53:16','2022-01-02 11:53:44','2022-01-02 11:53:45','','','',NULL),(1070000014,'','3','2022-01-02 11:53:23','2022-01-02 11:53:46','2022-01-02 11:53:47','','','',NULL),(1070000015,'3','3','2022-01-02 11:53:26','2022-01-02 11:53:48','2022-01-02 11:53:50','','','',NULL),(1070000016,'3','3','2022-01-02 11:53:27','2022-01-02 11:53:52','2022-01-02 11:53:54','','','',NULL),(1070000017,'','3','2022-01-02 11:54:01',NULL,NULL,'',NULL,NULL,NULL),(1070000018,'','3','2022-01-02 11:54:06',NULL,NULL,'',NULL,NULL,NULL),(1070000019,'','3','2022-01-02 11:54:07',NULL,NULL,'',NULL,NULL,NULL),(1070000020,'4','1','2022-01-02 11:54:10',NULL,NULL,'',NULL,NULL,'1'),(1070000021,'','1','2022-01-02 11:54:11',NULL,NULL,'',NULL,NULL,NULL),(1070000022,'3','1','2022-01-02 11:54:11',NULL,NULL,'',NULL,NULL,NULL),(1070000023,'4','1','2022-01-02 11:54:12',NULL,NULL,'',NULL,NULL,NULL),(1070000024,'','3','2022-01-02 11:54:13',NULL,NULL,'',NULL,NULL,NULL),(1070000025,'','3','2022-01-02 11:54:13',NULL,NULL,'',NULL,NULL,NULL),(1070000026,'4','1','2022-01-02 11:54:13',NULL,NULL,'',NULL,NULL,NULL),(1070000027,'','3','2022-01-02 11:54:14',NULL,NULL,'',NULL,NULL,NULL);
/*!40000 ALTER TABLE `b_queue_call` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_queue_date`
--

DROP TABLE IF EXISTS `b_queue_date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_queue_date` (
  `b_queue_date_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `queue_id` bigint(20) DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `queue_current` varchar(255) DEFAULT NULL COMMENT 'ตอนนี้ ถึงคิว ที่เท่าไร จะได้รู้ว่าต้องรอ อีกกี่คิว',
  `queue` int(11) DEFAULT NULL COMMENT 'คิวที่กดได้ เลขที่คิว',
  PRIMARY KEY (`b_queue_date_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1020000047 DEFAULT CHARSET=utf8 COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue_date`
--

LOCK TABLES `b_queue_date` WRITE;
/*!40000 ALTER TABLE `b_queue_date` DISABLE KEYS */;
INSERT INTO `b_queue_date` VALUES (1020000040,106000005,'2021-12-30','0',0),(1020000020,106000008,'2021-12-29','0',0),(1020000019,106000007,'2021-12-29','0',0),(1020000018,106000006,'2021-12-29','0',0),(1020000017,106000005,'2021-12-29','0',0),(1020000041,106000005,'2021-12-31','0',4),(1020000042,106000009,'2021-12-31','0',0),(1020000043,106000010,'2021-12-31','0',1),(1020000044,106000005,'2022-01-03','2',0),(1020000045,106000009,'2022-01-03','0',0),(1020000046,106000010,'2022-01-03','0',0);
/*!40000 ALTER TABLE `b_queue_date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_staff`
--

DROP TABLE IF EXISTS `b_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_staff` (
  `staff_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `staff_code` varchar(255) DEFAULT NULL,
  `prefix_id` bigint(20) DEFAULT NULL,
  `prefix` varchar(255) DEFAULT NULL,
  `staff_fname_t` varchar(255) DEFAULT NULL,
  `staff_fname_e` varchar(255) DEFAULT NULL,
  `staff_lname_t` varchar(255) DEFAULT NULL,
  `staff_lname_e` varchar(255) DEFAULT NULL,
  `staff_username` varchar(255) DEFAULT NULL,
  `staff_password` varchar(255) DEFAULT NULL,
  `staff_active` varchar(255) DEFAULT NULL,
  `staff_remark` varchar(255) DEFAULT NULL,
  `priority` varchar(255) DEFAULT NULL,
  `tele` varchar(255) DEFAULT NULL,
  `mobile` varchar(255) DEFAULT NULL,
  `fax` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `position_id` varchar(255) DEFAULT NULL,
  `position_name` varchar(255) DEFAULT NULL,
  `date_create` varchar(255) DEFAULT NULL,
  `date_modi` varchar(255) DEFAULT NULL,
  `date_cancel` varchar(255) DEFAULT NULL,
  `user_create` varchar(255) DEFAULT NULL,
  `user_modi` varchar(255) DEFAULT NULL,
  `user_cancel` varchar(255) DEFAULT NULL,
  `sort1` varchar(255) DEFAULT NULL,
  `id_card` varchar(255) DEFAULT NULL,
  `tax_id` varchar(255) DEFAULT NULL,
  `queue_current` varchar(255) DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `active` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`staff_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1030000000 DEFAULT CHARSET=utf8 COMMENT='id=103';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_staff`
--

LOCK TABLES `b_staff` WRITE;
/*!40000 ALTER TABLE `b_staff` DISABLE KEYS */;
INSERT INTO `b_staff` VALUES (1,'001',4,'นายแพทย์','อรรถสิทธิ์ ',NULL,'ทองปลาเค้า',NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'100000',NULL,NULL,'','2018-03-16 18:20:29',NULL),(2,'002',4,'นายแพทย์','ทดสอบ',NULL,'Test',NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'100001',NULL,NULL,'3',NULL,NULL);
/*!40000 ALTER TABLE `b_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_position`
--

DROP TABLE IF EXISTS `f_position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_position` (
  `position_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `position_code` varchar(255) DEFAULT NULL,
  `position_name_t` varchar(255) DEFAULT NULL,
  `position_name_e` varchar(255) DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `position_active` varchar(255) DEFAULT NULL,
  `status_position` varchar(255) DEFAULT NULL COMMENT '1=staff 2= doctor',
  PRIMARY KEY (`position_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1040000000 DEFAULT CHARSET=utf8 COMMENT='id=104';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_position`
--

LOCK TABLES `f_position` WRITE;
/*!40000 ALTER TABLE `f_position` DISABLE KEYS */;
INSERT INTO `f_position` VALUES (1,'001','แพทย์',NULL,NULL,'1','1');
/*!40000 ALTER TABLE `f_position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_queue`
--

DROP TABLE IF EXISTS `t_queue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_queue` (
  `t_queue_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `queue_id` bigint(20) DEFAULT NULL,
  `b_queue_date_id` bigint(20) DEFAULT NULL,
  `queue` int(11) DEFAULT NULL,
  `queue_current` int(11) DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `status_queue` varchar(255) DEFAULT NULL COMMENT '1=queue 2 = finish queue',
  `status_lock` varchar(45) DEFAULT NULL COMMENT '0=default;1=lock กำลังเรียกคิว;2=เรียบร้อย',
  `active` varchar(45) DEFAULT NULL,
  `queue_call_id` bigint(20) DEFAULT NULL,
  `row_1` varchar(255) DEFAULT NULL,
  `queue_active` varchar(255) DEFAULT NULL,
  `queue_name` varchar(255) DEFAULT NULL,
  `date_begin` varchar(255) DEFAULT NULL,
  `date_finish` varchar(255) DEFAULT NULL,
  `date_create` varchar(45) DEFAULT NULL,
  `date_modi` varchar(45) DEFAULT NULL,
  `date_cancel` varchar(45) DEFAULT NULL,
  `user_create` varchar(45) DEFAULT NULL,
  `user_modi` varchar(45) DEFAULT NULL,
  `user_cancel` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`t_queue_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1050000196 DEFAULT CHARSET=utf8 COMMENT='id=105';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_queue`
--

LOCK TABLES `t_queue` WRITE;
/*!40000 ALTER TABLE `t_queue` DISABLE KEYS */;
INSERT INTO `t_queue` VALUES (1050000189,106000009,1020000042,2,1,'2021-12-31','2','2','1',NULL,NULL,NULL,NULL,'2021-12-31 21:39:16','2021-12-31 21:39:33','2021-12-31 21:39:16',NULL,NULL,'',NULL,NULL),(1050000190,106000009,1020000042,1,2,'2021-12-31','1','1','1',NULL,NULL,NULL,NULL,'2021-12-31 21:51:39','','2021-12-31 21:51:39',NULL,NULL,'',NULL,NULL),(1050000191,106000009,1020000042,2,1,'2021-12-31','1','1','1',NULL,NULL,NULL,NULL,'2021-12-31 21:51:39','','2021-12-31 21:51:39',NULL,NULL,'',NULL,NULL),(1050000192,106000009,1020000042,1,2,'2021-12-31','1','1','1',NULL,NULL,NULL,NULL,'2021-12-31 21:56:26','','2021-12-31 21:56:26',NULL,NULL,'',NULL,NULL),(1050000193,106000009,1020000042,2,1,'2021-12-31','1','1','1',NULL,NULL,NULL,NULL,'2021-12-31 21:56:27','','2021-12-31 21:56:27',NULL,NULL,'',NULL,NULL),(1050000188,106000009,1020000042,1,2,'2021-12-31','2','2','1',NULL,NULL,NULL,NULL,'2021-12-31 21:39:15','2021-12-31 21:39:28','2021-12-31 21:39:15',NULL,NULL,'',NULL,NULL),(1050000187,106000010,1020000043,1,1,'2021-12-31','1','1','1',NULL,NULL,NULL,NULL,'2021-12-31 21:29:32','','2021-12-31 21:29:32',NULL,NULL,'',NULL,NULL),(1050000182,106000005,1020000041,1,4,'2021-12-31','2','2','1',NULL,NULL,NULL,NULL,'2021-12-31 13:02:30','2021-12-31 13:03:50','2021-12-31 13:02:30',NULL,NULL,'',NULL,NULL),(1050000183,106000005,1020000041,2,3,'2021-12-31','2','2','1',NULL,NULL,NULL,NULL,'2021-12-31 13:02:30','2021-12-31 13:04:13','2021-12-31 13:02:30',NULL,NULL,'',NULL,NULL),(1050000184,106000005,1020000041,3,2,'2021-12-31','2','2','1',NULL,NULL,NULL,NULL,'2021-12-31 13:02:31','2021-12-31 21:36:14','2021-12-31 13:02:31',NULL,NULL,'',NULL,NULL),(1050000185,106000005,1020000041,4,1,'2021-12-31','2','2','1',NULL,NULL,NULL,NULL,'2021-12-31 13:02:32','2021-12-31 21:39:21','2021-12-31 13:02:32',NULL,NULL,'',NULL,NULL),(1050000186,106000009,1020000042,1,1,'2021-12-31','1','1','1',NULL,NULL,NULL,NULL,'2021-12-31 13:03:54','','2021-12-31 13:03:54',NULL,NULL,'',NULL,NULL),(1050000194,106000005,1020000044,1,0,'2022-01-03','1','0','1',NULL,NULL,NULL,NULL,'2022-01-03 07:04:45','','2022-01-03 07:04:45',NULL,NULL,'',NULL,NULL),(1050000195,106000005,1020000044,2,1,'2022-01-03','1','0','1',NULL,NULL,NULL,NULL,'2022-01-03 07:22:01','','2022-01-03 07:22:01',NULL,NULL,'',NULL,NULL);
/*!40000 ALTER TABLE `t_queue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'modernpos_queue'
--
/*!50003 DROP PROCEDURE IF EXISTS `finishque_newque` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `finishque_newque`(IN t_que_id varchar(20),IN queue_date_id1 bigint, IN user_id1 varchar(20), out ret varchar(20))
BEGIN
	DECLARE queue11 int DEFAULT 0;
    DECLARE queue_current1 int DEFAULT 0;
    DECLARE queueid bigint DEFAULT 0;
    DECLARE queuedateid bigint DEFAULT 0;
    DECLARE queueidnew bigint DEFAULT 0;
    DECLARE queuedate varchar(20) DEFAULT '';
	-- finish que
	update t_queue set status_queue = '2', status_lock = '2' where t_queue_id = t_que_id;
    -- update b_queue_date set queue_current = queue_current - 1 where b_queue_date_id = queue_date_id1;
    -- new que
    select queue into queue11 from b_queue_date Where b_queue_date_id = queue_date_id1;
    select queue_current into queue_current1 from b_queue_date Where queueid = queue_date_id1;
    select queue_id into queueid from b_queue_date where b_queue_date_id = queue_date_id1;
    -- select queue_id into queueidnew from b_queue_date where b_queue_date_id = queue_date_id1;
    select queue_date into queuedate from b_queue_date where b_queue_date_id = queue_date_id1;
    set queue11 = queue11 + 1;
    insert into t_queue set 
    queue_id = queueid
    ,b_queue_date_id = queue_date_id1
    ,queue=queue11
    ,queue_date=queuedate
    ,status_queue='1'
    ,status_lock='0'
    ,date_begin=now()
    ,date_create=now()
    ,active='1'
    ,user_create=user_id1
    ,date_finish=''
    ,queue_current=queue_current1
    ;
    
    select count(1) as cnt into queue_current1  from t_queue where b_queue_date_id = queue_date_id1 and active = '1' and status_lock = '0' and status_queue = '1';
    update b_queue_date set queue_current = queue_current1 where b_queue_date_id = queue_date_id1;
    
    set ret = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `gen_queue_next` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `gen_queue_next`(IN queue_id1 bigint,IN b_queue_date_id1 bigint, IN queue_date1 varchar(20), IN user_id1 varchar(20))
BEGIN
	DECLARE t_queue_id1 bigint;
	DECLARE queue11 int DEFAULT 0;
    DECLARE queue_current1 int DEFAULT 0;
	-- select queue into queue11 from b_queue_date Where queue_id = queue_id1 and queue_date = queue_date1 ;
    select queue into queue11 from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_lock = '0' and status_queue = '1' order by t_queue_id desc limit 0,1;
    
    select queue_current into queue_current1 from b_queue_date Where queue_id = queue_id1 and queue_date = queue_date1;
    set queue11 = queue11 + 1;
    -- select t_queue_id into t_queue_id1 from t_queue where queue_id = queue_id and queue_date = queue_date and active = '1' and status_queue = '2' order by t_queue_id asc;
	-- Update b_queue_date Set queue = queue11 Where b_queue_date_id = b_queue_date_id1;
    
    insert into t_queue set queue_id = queue_id1,queue=queue11,active='1',date_create=now(),user_create=user_id1
    ,status_queue='1',date_begin=now(),date_finish='',queue_current=queue_current1,queue_date=queue_date1
    ,status_lock='0',b_queue_date_id=b_queue_date_id1
    ;
    select count(1) as cnt into queue_current1  from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_lock = '0' and status_queue = '1';
    update b_queue_date set queue_current = queue_current1 where b_queue_date_id = b_queue_date_id1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `lock_queue` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `lock_queue`(IN b_queue_date_id1 varchar(20),IN t_que_id_old varchar(20), IN queue_caller_id varchar(20))
BEGIN
	DECLARE que_curr int DEFAULT 0;
    DECLARE queue1 int DEFAULT 0;
    DECLARE tqueueid int DEFAULT 0;
    DECLARE queue_current1 int DEFAULT 0;
    
    select count(1) into que_curr from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_queue = '1' and status_lock = '0';
    select t_queue_id into tqueueid from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_queue = '1' and status_lock = '0' order by t_queue_id limit 0,1;
	update t_queue set status_lock = '1',queue_current = que_curr, queue_caller_id = queue_caller_id where t_queue_id = tqueueid;
    update t_queue set status_queue = '2', status_lock = '2',date_finish=now() where t_queue_id = t_que_id_old;	-- finishque
    
    select queue into queue1 from t_queue where t_queue_id = tqueueid;
    
    select count(1) as cnt into queue_current1  from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_lock = '0' and status_queue = '1';
    update b_queue_date set queue_current = queue_current1, queue = queue1 where b_queue_date_id = b_queue_date_id1;
    
    select * from t_queue where t_queue_id = tqueueid ;
    
    
    
    -- SET ret = tqueueid;
    -- return que_curr;
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

-- Dump completed on 2022-01-03  7:45:55
