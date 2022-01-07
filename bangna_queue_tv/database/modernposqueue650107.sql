-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: modernpos_queue
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `b_company` (
  `comp_id` bigint NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `b_prefix` (
  `prefix_id` bigint NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `b_queue` (
  `queue_id` bigint NOT NULL AUTO_INCREMENT,
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
  `status_everyday` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=every day เป็น คิวที่ ต้องใช้ทุกวัน',
  PRIMARY KEY (`queue_id`)
) ENGINE=MyISAM AUTO_INCREMENT=106000021 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=106';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue`
--

LOCK TABLES `b_queue` WRITE;
/*!40000 ALTER TABLE `b_queue` DISABLE KEYS */;
INSERT INTO `b_queue` VALUES (106000007,'','cccccc',NULL,NULL,'1','2021-12-29 09:49:37',NULL,NULL,'',NULL,NULL,NULL),(106000006,'','bbbbb',NULL,NULL,'1','2021-12-29 09:49:36',NULL,NULL,'',NULL,NULL,NULL),(106000005,'xxxx','aaaaa','A','5','1','2021-12-29 09:49:35','2021-12-31 07:39:28',NULL,'','',NULL,NULL),(106000008,'','dddddd',NULL,NULL,'1','2021-12-29 09:52:00',NULL,NULL,'',NULL,NULL,NULL),(106000009,'xxxx','eeeeee','E','','1','2021-12-31 07:40:00',NULL,NULL,'',NULL,NULL,NULL),(106000010,'xxxx','fffff','F','10','1','2021-12-31 07:40:21',NULL,NULL,'',NULL,NULL,NULL),(106000011,'','1','','','1','2022-01-06 14:10:12',NULL,NULL,'',NULL,NULL,NULL),(106000012,'','2','','','1','2022-01-06 14:10:13',NULL,NULL,'',NULL,NULL,NULL),(106000013,'','3','','','1','2022-01-06 14:10:14',NULL,NULL,'',NULL,NULL,NULL),(106000014,'','4','','','1','2022-01-06 14:10:14',NULL,NULL,'',NULL,NULL,NULL),(106000015,'','5','','','1','2022-01-06 14:10:15',NULL,NULL,'',NULL,NULL,NULL),(106000016,'','6','','','1','2022-01-06 14:10:15',NULL,NULL,'',NULL,NULL,NULL),(106000017,'','7','','','1','2022-01-06 14:10:15',NULL,NULL,'',NULL,NULL,NULL),(106000018,'','8','','','1','2022-01-06 14:10:16',NULL,NULL,'',NULL,NULL,NULL),(106000019,'','9','','','1','2022-01-06 14:10:16',NULL,NULL,'',NULL,NULL,NULL),(106000020,'','10','','','1','2022-01-06 14:10:16',NULL,NULL,'',NULL,NULL,NULL);
/*!40000 ALTER TABLE `b_queue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_queue_call`
--

DROP TABLE IF EXISTS `b_queue_call`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `b_queue_call` (
  `queue_call_id` bigint NOT NULL AUTO_INCREMENT,
  `queue_call_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_lock` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=lock มีคนใช้งานอยู่',
  PRIMARY KEY (`queue_call_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1070000028 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=107';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue_call`
--

LOCK TABLES `b_queue_call` WRITE;
/*!40000 ALTER TABLE `b_queue_call` DISABLE KEYS */;
INSERT INTO `b_queue_call` VALUES (1070000000,'','3','2022-01-02 11:25:02','2022-01-02 11:39:40','2022-01-02 11:39:41','','','',NULL),(1070000001,'','3','2022-01-02 11:25:02','2022-01-02 11:39:44','2022-01-02 11:39:45','','','',NULL),(1070000002,'1','1','2022-01-02 11:25:16','2022-01-02 11:54:12',NULL,'','',NULL,NULL),(1070000003,'2','1','2022-01-02 11:25:16','2022-01-02 11:54:11',NULL,'','',NULL,'1'),(1070000004,'3','1','2022-01-02 11:25:17','2022-01-02 11:53:58',NULL,'','',NULL,'1'),(1070000005,'2','3','2022-01-02 11:25:18','2022-01-02 11:39:48','2022-01-02 11:39:49','','','',NULL),(1070000006,'2','3','2022-01-02 11:25:19','2022-01-02 11:39:51','2022-01-02 11:39:52','','','',NULL),(1070000007,'1','3','2022-01-02 11:25:19','2022-01-02 11:39:54','2022-01-02 11:39:55','','','',NULL),(1070000008,'1','3','2022-01-02 11:25:45','2022-01-02 11:39:57','2022-01-02 11:39:58','','','',NULL),(1070000009,'','3','2022-01-02 11:46:26','2022-01-02 11:53:32','2022-01-02 11:53:33','','','',NULL),(1070000010,'','3','2022-01-02 11:46:39','2022-01-02 11:53:35','2022-01-02 11:53:36','','','',NULL),(1070000011,'','3','2022-01-02 11:52:09','2022-01-02 11:53:38','2022-01-02 11:53:39','','','',NULL),(1070000012,'','3','2022-01-02 11:52:19','2022-01-02 11:53:41','2022-01-02 11:53:42','','','',NULL),(1070000013,'','3','2022-01-02 11:53:16','2022-01-02 11:53:44','2022-01-02 11:53:45','','','',NULL),(1070000014,'','3','2022-01-02 11:53:23','2022-01-02 11:53:46','2022-01-02 11:53:47','','','',NULL),(1070000015,'3','3','2022-01-02 11:53:26','2022-01-02 11:53:48','2022-01-02 11:53:50','','','',NULL),(1070000016,'3','3','2022-01-02 11:53:27','2022-01-02 11:53:52','2022-01-02 11:53:54','','','',NULL),(1070000017,'','3','2022-01-02 11:54:01',NULL,NULL,'',NULL,NULL,NULL),(1070000018,'','3','2022-01-02 11:54:06',NULL,NULL,'',NULL,NULL,NULL),(1070000019,'','3','2022-01-02 11:54:07',NULL,NULL,'',NULL,NULL,NULL),(1070000020,'4','1','2022-01-02 11:54:10',NULL,NULL,'',NULL,NULL,'1'),(1070000021,'','1','2022-01-02 11:54:11',NULL,NULL,'',NULL,NULL,NULL),(1070000022,'3','1','2022-01-02 11:54:11',NULL,NULL,'',NULL,NULL,NULL),(1070000023,'4','1','2022-01-02 11:54:12',NULL,NULL,'',NULL,NULL,NULL),(1070000024,'','3','2022-01-02 11:54:13',NULL,NULL,'',NULL,NULL,NULL),(1070000025,'','3','2022-01-02 11:54:13',NULL,NULL,'',NULL,NULL,NULL),(1070000026,'4','1','2022-01-02 11:54:13',NULL,NULL,'',NULL,NULL,NULL),(1070000027,'','3','2022-01-02 11:54:14',NULL,NULL,'',NULL,NULL,NULL);
/*!40000 ALTER TABLE `b_queue_call` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_queue_date`
--

DROP TABLE IF EXISTS `b_queue_date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `b_queue_date` (
  `b_queue_date_id` bigint NOT NULL AUTO_INCREMENT,
  `queue_id` bigint DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `queue_current` varchar(255) DEFAULT NULL COMMENT 'ตอนนี้ ถึงคิว ที่เท่าไร จะได้รู้ว่าต้องรอ อีกกี่คิว',
  `queue` int DEFAULT NULL COMMENT 'คิวที่กดได้ เลขที่คิว',
  PRIMARY KEY (`b_queue_date_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1020000072 DEFAULT CHARSET=utf8 COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue_date`
--

LOCK TABLES `b_queue_date` WRITE;
/*!40000 ALTER TABLE `b_queue_date` DISABLE KEYS */;
INSERT INTO `b_queue_date` VALUES (1020000055,106000010,'2022-01-05','0',0),(1020000054,106000009,'2022-01-05','0',0),(1020000053,106000005,'2022-01-05','0',0),(1020000056,106000005,'2022-01-06','3',0),(1020000057,106000009,'2022-01-06','3',0),(1020000058,106000010,'2022-01-06','11',0),(1020000059,106000011,'2022-01-06','0',0),(1020000060,106000012,'2022-01-06','0',0),(1020000061,106000013,'2022-01-06','0',0),(1020000062,106000014,'2022-01-06','0',0),(1020000063,106000015,'2022-01-06','0',0),(1020000064,106000016,'2022-01-06','0',0),(1020000065,106000017,'2022-01-06','0',0),(1020000066,106000018,'2022-01-06','0',0),(1020000067,106000019,'2022-01-06','0',0),(1020000068,106000020,'2022-01-06','0',0),(1020000069,106000005,'2022-01-07','6',10),(1020000070,106000009,'2022-01-07','0',0),(1020000071,106000010,'2022-01-07','0',0);
/*!40000 ALTER TABLE `b_queue_date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_staff`
--

DROP TABLE IF EXISTS `b_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `b_staff` (
  `staff_id` bigint NOT NULL AUTO_INCREMENT,
  `staff_code` varchar(255) DEFAULT NULL,
  `prefix_id` bigint DEFAULT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `f_position` (
  `position_id` bigint NOT NULL AUTO_INCREMENT,
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
-- Table structure for table `t_call`
--

DROP TABLE IF EXISTS `t_call`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_call` (
  `call_id` bigint NOT NULL AUTO_INCREMENT,
  `queue_id` bigint DEFAULT NULL,
  `t_queue_id` bigint DEFAULT NULL,
  `queue` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `prefix` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `code` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `caller` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `status_call` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=called เสียงเรียบร้อย',
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`call_id`)
) ENGINE=MyISAM AUTO_INCREMENT=108000061 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=108';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_call`
--

LOCK TABLES `t_call` WRITE;
/*!40000 ALTER TABLE `t_call` DISABLE KEYS */;
INSERT INTO `t_call` VALUES (108000025,106000005,1050000271,'19','A','xxxx','3','0','2022-01-07 13:40:51',NULL,NULL,NULL,NULL,NULL),(108000024,106000005,1050000270,'18','A','xxxx','3','0','2022-01-07 13:40:48',NULL,NULL,NULL,NULL,NULL),(108000023,106000005,1050000270,'18','A','xxxx','3','0','2022-01-07 13:40:45',NULL,NULL,NULL,NULL,NULL),(108000022,106000005,1050000269,'17','A','xxxx','3','0','2022-01-07 13:40:39',NULL,NULL,NULL,NULL,NULL),(108000020,106000005,1050000268,'16','A','xxxx','3','0','2022-01-07 13:40:32',NULL,NULL,NULL,NULL,NULL),(108000021,106000005,1050000269,'17','A','xxxx','3','0','2022-01-07 13:40:36',NULL,NULL,NULL,NULL,NULL),(108000019,106000005,1050000268,'16','A','xxxx','3','0','2022-01-07 13:40:29',NULL,NULL,NULL,NULL,NULL),(108000018,106000005,1050000267,'15','A','xxxx','3','0','2022-01-07 13:40:25',NULL,NULL,NULL,NULL,NULL),(108000017,106000005,1050000267,'15','A','xxxx','3','0','2022-01-07 13:40:22',NULL,NULL,NULL,NULL,NULL),(108000016,106000005,1050000261,'15','A','xxxx','4','0','2022-01-07 13:40:07',NULL,NULL,NULL,NULL,NULL),(108000015,106000005,1050000261,'15','A','xxxx','4','0','2022-01-07 13:38:42',NULL,NULL,NULL,NULL,NULL),(108000026,106000005,1050000271,'19','A','xxxx','3','0','2022-01-07 13:41:01',NULL,NULL,NULL,NULL,NULL),(108000027,106000005,1050000272,'1','A','xxxx','3','0','2022-01-07 14:08:34',NULL,NULL,NULL,NULL,NULL),(108000028,106000005,1050000272,'1','A','xxxx','3','0','2022-01-07 14:09:19',NULL,NULL,NULL,NULL,NULL),(108000029,106000005,1050000273,'2','A','xxxx','3','0','2022-01-07 14:09:23',NULL,NULL,NULL,NULL,NULL),(108000030,106000005,1050000273,'2','A','xxxx','3','0','2022-01-07 14:09:29',NULL,NULL,NULL,NULL,NULL),(108000031,106000005,1050000274,'3','A','xxxx','3','0','2022-01-07 14:09:41',NULL,NULL,NULL,NULL,NULL),(108000032,106000005,1050000274,'3','A','xxxx','3','0','2022-01-07 14:09:47',NULL,NULL,NULL,NULL,NULL),(108000033,106000005,1050000275,'4','A','xxxx','3','0','2022-01-07 14:10:29',NULL,NULL,NULL,NULL,NULL),(108000034,106000005,1050000275,'4','A','xxxx','3','0','2022-01-07 14:10:40',NULL,NULL,NULL,NULL,NULL),(108000035,106000005,1050000276,'5','A','xxxx','3','0','2022-01-07 14:10:52',NULL,NULL,NULL,NULL,NULL),(108000036,106000005,1050000277,'6','A','xxxx','3','0','2022-01-07 15:42:08',NULL,NULL,NULL,NULL,NULL),(108000037,106000005,1050000277,'6','A','xxxx','3','0','2022-01-07 15:42:22',NULL,NULL,NULL,NULL,NULL),(108000038,106000005,1050000278,'7','A','xxxx','3','0','2022-01-07 15:42:34',NULL,NULL,NULL,NULL,NULL),(108000039,106000005,1050000278,'7','A','xxxx','3','0','2022-01-07 15:42:46',NULL,NULL,NULL,NULL,NULL),(108000040,106000005,1050000279,'8','A','xxxx','3','0','2022-01-07 15:42:59',NULL,NULL,NULL,NULL,NULL),(108000041,106000005,1050000279,'8','A','xxxx','3','0','2022-01-07 15:43:10',NULL,NULL,NULL,NULL,NULL),(108000042,106000005,1050000283,'1','A','xxxx','3','0','2022-01-07 16:09:26',NULL,NULL,NULL,NULL,NULL),(108000043,106000005,1050000283,'1','A','xxxx','3','0','2022-01-07 16:13:03',NULL,NULL,NULL,NULL,NULL),(108000044,106000005,1050000284,'2','A','xxxx','3','0','2022-01-07 16:22:06',NULL,NULL,NULL,NULL,NULL),(108000045,106000005,1050000284,'2','A','xxxx','3','0','2022-01-07 16:22:17',NULL,NULL,NULL,NULL,NULL),(108000046,106000005,1050000285,'3','A','xxxx','3','0','2022-01-07 16:22:29',NULL,NULL,NULL,NULL,NULL),(108000047,106000005,1050000285,'3','A','xxxx','3','0','2022-01-07 16:22:40',NULL,NULL,NULL,NULL,NULL),(108000048,106000005,1050000286,'4','A','xxxx','3','0','2022-01-07 16:23:34',NULL,NULL,NULL,NULL,NULL),(108000049,106000005,1050000286,'4','A','xxxx','3','0','2022-01-07 16:23:45',NULL,NULL,NULL,NULL,NULL),(108000050,106000005,1050000287,'5','A','xxxx','3','0','2022-01-07 16:23:56',NULL,NULL,NULL,NULL,NULL),(108000051,106000005,1050000287,'5','A','xxxx','3','0','2022-01-07 16:24:06',NULL,NULL,NULL,NULL,NULL),(108000052,106000005,1050000288,'6','A','xxxx','3','0','2022-01-07 16:24:17',NULL,NULL,NULL,NULL,NULL),(108000053,106000005,1050000288,'6','A','xxxx','3','0','2022-01-07 16:24:26',NULL,NULL,NULL,NULL,NULL),(108000054,106000005,1050000289,'7','A','xxxx','4','0','2022-01-07 16:31:35',NULL,NULL,NULL,NULL,NULL),(108000055,106000005,1050000289,'7','A','xxxx','4','0','2022-01-07 16:31:52',NULL,NULL,NULL,NULL,NULL),(108000056,106000005,1050000290,'8','A','xxxx','4','0','2022-01-07 16:32:53',NULL,NULL,NULL,NULL,NULL),(108000057,106000005,1050000290,'8','A','xxxx','4','0','2022-01-07 16:33:04',NULL,NULL,NULL,NULL,NULL),(108000058,106000005,1050000291,'9','A','xxxx','4','0','2022-01-07 16:33:27',NULL,NULL,NULL,NULL,NULL),(108000059,106000005,1050000291,'9','A','xxxx','4','0','2022-01-07 16:34:28',NULL,NULL,NULL,NULL,NULL),(108000060,106000005,1050000292,'10','A','xxxx','4','0','2022-01-07 16:34:54',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `t_call` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_queue`
--

DROP TABLE IF EXISTS `t_queue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_queue` (
  `t_queue_id` bigint NOT NULL AUTO_INCREMENT,
  `queue_id` bigint DEFAULT NULL,
  `b_queue_date_id` bigint DEFAULT NULL,
  `queue` int DEFAULT NULL,
  `queue_current` int DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `status_queue` varchar(255) DEFAULT NULL COMMENT '1=queue 2 = finish queue',
  `status_lock` varchar(45) DEFAULT NULL COMMENT '0=default;1=lock กำลังเรียกคิว;2=เรียบร้อย',
  `active` varchar(45) DEFAULT NULL,
  `queue_call_id` bigint DEFAULT NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=1050000299 DEFAULT CHARSET=utf8 COMMENT='id=105';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_queue`
--

LOCK TABLES `t_queue` WRITE;
/*!40000 ALTER TABLE `t_queue` DISABLE KEYS */;
INSERT INTO `t_queue` VALUES (1050000294,106000005,1020000069,12,5,'2022-01-07','1','0','1',NULL,NULL,NULL,NULL,'2022-01-07 16:31:12','','2022-01-07 16:31:12',NULL,NULL,'',NULL,NULL),(1050000298,106000005,1020000069,16,9,'2022-01-07','1','0','1',NULL,NULL,NULL,NULL,'2022-01-07 16:31:16','','2022-01-07 16:31:16',NULL,NULL,'',NULL,NULL),(1050000297,106000005,1020000069,15,8,'2022-01-07','1','0','1',NULL,NULL,NULL,NULL,'2022-01-07 16:31:15','','2022-01-07 16:31:15',NULL,NULL,'',NULL,NULL),(1050000296,106000005,1020000069,14,7,'2022-01-07','1','0','1',NULL,NULL,NULL,NULL,'2022-01-07 16:31:14','','2022-01-07 16:31:14',NULL,NULL,'',NULL,NULL),(1050000295,106000005,1020000069,13,6,'2022-01-07','1','0','1',NULL,NULL,NULL,NULL,'2022-01-07 16:31:13','','2022-01-07 16:31:13',NULL,NULL,'',NULL,NULL),(1050000293,106000005,1020000069,11,4,'2022-01-07','1','0','1',NULL,NULL,NULL,NULL,'2022-01-07 16:31:11','','2022-01-07 16:31:11',NULL,NULL,'',NULL,NULL),(1050000292,106000005,1020000069,10,9,'2022-01-07','2','2','1',1070000020,NULL,NULL,NULL,'2022-01-07 16:08:07','2022-01-07 16:34:54','2022-01-07 16:08:07',NULL,NULL,'',NULL,NULL),(1050000291,106000005,1020000069,9,8,'2022-01-07','2','2','1',1070000020,NULL,NULL,NULL,'2022-01-07 16:08:05','2022-01-07 16:34:28','2022-01-07 16:08:05',NULL,NULL,'',NULL,NULL),(1050000290,106000005,1020000069,8,7,'2022-01-07','2','2','1',1070000020,NULL,NULL,NULL,'2022-01-07 16:08:04','2022-01-07 16:33:04','2022-01-07 16:08:04',NULL,NULL,'',NULL,NULL),(1050000288,106000005,1020000069,6,5,'2022-01-07','2','2','1',1070000004,NULL,NULL,NULL,'2022-01-07 16:08:01','2022-01-07 16:24:26','2022-01-07 16:08:01',NULL,NULL,'',NULL,NULL),(1050000289,106000005,1020000069,7,10,'2022-01-07','2','2','1',1070000020,NULL,NULL,NULL,'2022-01-07 16:08:03','2022-01-07 16:31:52','2022-01-07 16:08:03',NULL,NULL,'',NULL,NULL),(1050000285,106000005,1020000069,3,2,'2022-01-07','2','2','1',1070000004,NULL,NULL,NULL,'2022-01-07 16:07:57','2022-01-07 16:22:40','2022-01-07 16:07:57',NULL,NULL,'',NULL,NULL),(1050000284,106000005,1020000069,2,9,'2022-01-07','2','2','1',1070000004,NULL,NULL,NULL,'2022-01-07 16:07:56','2022-01-07 16:22:17','2022-01-07 16:07:56',NULL,NULL,'',NULL,NULL),(1050000287,106000005,1020000069,5,4,'2022-01-07','2','2','1',1070000004,NULL,NULL,NULL,'2022-01-07 16:08:00','2022-01-07 16:24:06','2022-01-07 16:08:00',NULL,NULL,'',NULL,NULL),(1050000286,106000005,1020000069,4,3,'2022-01-07','2','2','1',1070000004,NULL,NULL,NULL,'2022-01-07 16:07:59','2022-01-07 16:23:45','2022-01-07 16:07:59',NULL,NULL,'',NULL,NULL),(1050000283,106000005,1020000069,1,10,'2022-01-07','2','2','1',1070000004,NULL,NULL,NULL,'2022-01-07 16:07:53','2022-01-07 16:13:03','2022-01-07 16:07:53',NULL,NULL,'',NULL,NULL);
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `finishque_newque`(IN t_que_id varchar(20),IN queue_date_id1 bigint, IN user_id1 varchar(20), IN queue_call_id varchar(20), out ret varchar(20))
BEGIN
	DECLARE queue11 int DEFAULT 0;
    DECLARE queue_current1 int DEFAULT 0;
    DECLARE queueid bigint DEFAULT 0;
    DECLARE queuedateid bigint DEFAULT 0;
    DECLARE queueidnew bigint DEFAULT 0;
    DECLARE queuedate varchar(20) DEFAULT '';
	
	update t_queue set status_queue = '2', status_lock = '2',date_finish=now(), queue_call_id = queue_call_id where t_queue_id = t_que_id;
    
    
    select queue into queue11 from b_queue_date Where b_queue_date_id = queue_date_id1;
    select queue_current into queue_current1 from b_queue_date Where queueid = queue_date_id1;
    select queue_id into queueid from b_queue_date where b_queue_date_id = queue_date_id1;
    
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
	
    -- ดึงเลข que ต่อไป
    select queue into queue11 from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_lock = '0' and status_queue = '1' order by t_queue_id desc limit 0,1;
    
    select queue_current into queue_current1 from b_queue_date Where queue_id = queue_id1 and queue_date = queue_date1;
    set queue11 = queue11 + 1;
    
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `lock_queue`(IN b_queue_date_id1 varchar(20),IN t_que_id_old varchar(20), IN queue_call_id1 varchar(20))
BEGIN
	DECLARE que_curr int DEFAULT 0;
    DECLARE queue1 int DEFAULT 0;
    DECLARE tqueueid int DEFAULT 0;
    DECLARE queue_current1 int DEFAULT 0;
    declare prefix1 varchar(20) default'';
    
    select count(1) into que_curr from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_queue = '1' and status_lock = '0';
    select t_queue_id into tqueueid from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_queue = '1' and status_lock = '0' order by t_queue_id limit 0,1;
	
    select queue into queue1 from t_queue where t_queue_id = tqueueid;
    
    if t_que_id_old<>'' then
		update t_queue set status_queue = '2', status_lock = '2',date_finish=now(), queue_call_id = queue_call_id1 where t_queue_id = t_que_id_old;	
        
		insert into t_call (queue_id, queue, prefix, code, caller, status_call, date_create,t_queue_id)
		select t_queue.queue_id, t_queue.queue,b_queue.queue_prefix,b_queue.queue_code,b_queue_call.queue_call_name,'0', now() ,t_que_id_old
		from t_queue     
		inner join b_queue on t_queue.queue_id = b_queue.queue_id  
		inner join b_queue_call on t_queue.queue_call_id = b_queue_call.queue_call_id
		where t_queue_id = t_que_id_old;
	else
		update t_queue set status_lock = '1',queue_current = que_curr, queue_call_id = queue_call_id1 where t_queue_id = tqueueid;
        
		insert into t_call (queue_id, queue, prefix, code, caller, status_call, date_create,t_queue_id)
		select t_queue.queue_id, t_queue.queue,b_queue.queue_prefix,b_queue.queue_code,b_queue_call.queue_call_name,'0', now() ,tqueueid
		from t_queue     
		left join b_queue on t_queue.queue_id = b_queue.queue_id  
		left join b_queue_call on t_queue.queue_call_id = b_queue_call.queue_call_id
		where t_queue_id = tqueueid ;
        
        
        -- insert into t_call set t_queue_id = tqueueid, queue = queue1;
		
        
        
	end if;
        
    
    
    select count(1) as cnt into queue_current1  from t_queue where b_queue_date_id = b_queue_date_id1 and active = '1' and status_lock = '0' and status_queue = '1';
    update b_queue_date set queue_current = queue_current1, queue = queue1 where b_queue_date_id = b_queue_date_id1;
    
    select * from t_queue where t_queue_id = tqueueid ;
    
    
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `void_clearque` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `void_clearque`(IN queue_date_id1 bigint, IN user_id1 varchar(20), in queue1 varchar(20), out ret varchar(20))
BEGIN
	-- 1.  ยกเลิก que ที่ค้าง  และ update 	queue ที่  b_queue_date
    DECLARE queue_id1 bigint DEFAULT 0;
    DECLARE queue_date1 varchar(20) DEFAULT "";
    select queue_id into queue_id1 from b_queue_date where b_queue_date_id = queue_date_id1;
    select queue_date into queue_date1 from b_queue_date where b_queue_date_id = queue_date_id1;
    
    -- 1.  ยกเลิก que
	update t_queue set active = '3',date_cancel=now(), user_cancel = user_id1 where b_queue_date_id = queue_date_id1 and status_queue = '1';
    -- queue ที่  b_queue_date
    update b_queue_date set queue_current = '1', queue='0' where b_queue_date_id = queue_date_id1;
    
    insert into t_queue set queue_id = queue_id1,queue=queue1,active='1',date_create=now(),user_create=user_id1
    ,status_queue='1',date_begin=now(),date_finish='',queue_current='0',queue_date=queue_date1
    ,status_lock='0',b_queue_date_id=queue_date_id1
    ;
    
    set ret = '1';
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

-- Dump completed on 2022-01-07 16:56:43
