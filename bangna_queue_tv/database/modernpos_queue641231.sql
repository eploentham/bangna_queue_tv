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
  `queue_prefix` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT 'ตัวย่อ ชื่อย่อ',
  `queue_start` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT 'คิวเริ่มต้น',
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
) ENGINE=MyISAM AUTO_INCREMENT=1020000041 DEFAULT CHARSET=utf8 COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue_date`
--

LOCK TABLES `b_queue_date` WRITE;
/*!40000 ALTER TABLE `b_queue_date` DISABLE KEYS */;
INSERT INTO `b_queue_date` VALUES (1020000040,106000005,'2021-12-30','0',6),(1020000020,106000008,'2021-12-29','1',3),(1020000019,106000007,'2021-12-29','1',3),(1020000018,106000006,'2021-12-29','1',4),(1020000017,106000005,'2021-12-29','1',5);
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
) ENGINE=MyISAM AUTO_INCREMENT=105000119 DEFAULT CHARSET=utf8 COMMENT='id=105';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_queue`
--

LOCK TABLES `t_queue` WRITE;
/*!40000 ALTER TABLE `t_queue` DISABLE KEYS */;
INSERT INTO `t_queue` VALUES (105000115,106000005,1020000040,3,4,'2021-12-30','2','2','1',NULL,NULL,NULL,'2021-12-30 19:04:04','2021-12-30 19:05:35','2021-12-30 19:04:04',NULL,NULL,'',NULL,NULL),(105000118,106000005,1020000040,6,1,'2021-12-30','1','1','1',NULL,NULL,NULL,'2021-12-30 19:04:36','','2021-12-30 19:04:36',NULL,NULL,'',NULL,NULL),(105000117,106000005,1020000040,5,2,'2021-12-30','2','2','1',NULL,NULL,NULL,'2021-12-30 19:04:33','2021-12-30 19:05:45','2021-12-30 19:04:33',NULL,NULL,'',NULL,NULL),(105000116,106000005,1020000040,4,3,'2021-12-30','2','2','1',NULL,NULL,NULL,'2021-12-30 19:04:31','2021-12-30 19:05:39','2021-12-30 19:04:31',NULL,NULL,'',NULL,NULL),(105000114,106000005,1020000040,2,5,'2021-12-30','2','2','1',NULL,NULL,NULL,'2021-12-30 18:56:51','2021-12-30 19:05:33','2021-12-30 18:56:51',NULL,NULL,'',NULL,NULL),(105000113,106000005,1020000040,1,6,'2021-12-30','2','2','1',NULL,NULL,NULL,'2021-12-30 18:56:50','2021-12-30 19:05:29','2021-12-30 18:56:50',NULL,NULL,'',NULL,NULL),(105000111,106000005,1020000039,2,2,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 18:33:39','2021-12-30 18:50:17','2021-12-30 18:33:39',NULL,'2021-12-30 18:56:45','',NULL,''),(105000112,106000005,1020000039,3,1,'2021-12-30','1','1','3',NULL,NULL,NULL,'2021-12-30 18:33:39','','2021-12-30 18:33:39',NULL,'2021-12-30 18:56:45','',NULL,''),(105000110,106000005,1020000039,1,3,'2021-12-30','1','1','3',NULL,NULL,NULL,'2021-12-30 18:33:38','','2021-12-30 18:33:38',NULL,'2021-12-30 18:56:45','',NULL,''),(105000109,106000005,1020000038,3,1,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 18:31:17','2021-12-30 18:32:25','2021-12-30 18:31:17',NULL,'2021-12-30 18:33:32','',NULL,''),(105000104,106000005,1020000037,4,3,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 13:08:49','2021-12-30 13:21:50','2021-12-30 13:08:49',NULL,'2021-12-30 18:30:52','',NULL,''),(105000103,106000005,1020000037,3,4,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 13:08:48','','2021-12-30 13:08:48',NULL,'2021-12-30 18:30:52','',NULL,''),(105000102,106000005,1020000037,2,5,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 13:08:47','','2021-12-30 13:08:47',NULL,'2021-12-30 18:30:52','',NULL,''),(105000101,106000005,1020000037,1,6,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 13:08:46','','2021-12-30 13:08:46',NULL,'2021-12-30 18:30:52','',NULL,''),(105000107,106000005,1020000038,1,3,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 18:31:15','2021-12-30 18:32:06','2021-12-30 18:31:15',NULL,'2021-12-30 18:33:32','',NULL,''),(105000108,106000005,1020000038,2,2,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 18:31:16','2021-12-30 18:32:15','2021-12-30 18:31:16',NULL,'2021-12-30 18:33:32','',NULL,''),(105000106,106000005,1020000037,6,1,'2021-12-30','1','1','3',NULL,NULL,NULL,'2021-12-30 13:14:09','','2021-12-30 13:14:09',NULL,'2021-12-30 18:30:52','',NULL,''),(105000105,106000005,1020000037,5,2,'2021-12-30','2','2','3',NULL,NULL,NULL,'2021-12-30 13:14:08','2021-12-30 13:21:58','2021-12-30 13:14:08',NULL,'2021-12-30 18:30:52','',NULL,'');
/*!40000 ALTER TABLE `t_queue` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-31  9:12:37
