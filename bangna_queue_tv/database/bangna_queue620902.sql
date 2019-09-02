-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: bangna_queue
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
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
  `comp_active` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`comp_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
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
  `prefix_id` int(11) NOT NULL AUTO_INCREMENT,
  `prefix_code` varchar(255) DEFAULT NULL,
  `prefix_name_t` varchar(255) DEFAULT NULL,
  `prefix_name_e` varchar(255) DEFAULT NULL,
  `prefix_active` varchar(255) DEFAULT NULL,
  `status_prefix` varchar(255) DEFAULT NULL COMMENT '1=บุคคล 2= นิติบุคคล',
  PRIMARY KEY (`prefix_id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
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
  `b_queue_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `staff_id` bigint(20) DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `queue_current` varchar(255) DEFAULT NULL COMMENT 'คิวที่เรียก',
  `queue` varchar(45) DEFAULT NULL COMMENT 'คิวที่กด',
  PRIMARY KEY (`b_queue_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1010000002 DEFAULT CHARSET=utf8 COMMENT='id=101';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_queue`
--

LOCK TABLES `b_queue` WRITE;
/*!40000 ALTER TABLE `b_queue` DISABLE KEYS */;
INSERT INTO `b_queue` VALUES (1010000000,1,'2019-09-02','0','10'),(1010000001,2,'2019-09-02','0','6');
/*!40000 ALTER TABLE `b_queue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_staff`
--

DROP TABLE IF EXISTS `b_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_staff` (
  `staff_id` bigint(20) NOT NULL,
  `staff_code` varchar(255) DEFAULT NULL,
  `prefix_id` int(11) DEFAULT NULL,
  `prefix` varchar(255) DEFAULT NULL,
  `staff_fname_t` varchar(255) DEFAULT NULL,
  `staff_fname_e` varchar(255) DEFAULT NULL,
  `staff_lname_t` varchar(255) DEFAULT NULL,
  `staff_lname_e` varchar(255) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password1` varchar(255) DEFAULT NULL,
  `active` varchar(255) DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
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
  PRIMARY KEY (`staff_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1020000000 DEFAULT CHARSET=utf8 COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_staff`
--

LOCK TABLES `b_staff` WRITE;
/*!40000 ALTER TABLE `b_staff` DISABLE KEYS */;
INSERT INTO `b_staff` VALUES (1,'001',4,'นายแพทย์','อรรถสิทธิ์ ',NULL,'ทองปลาเค้า',NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'100000',NULL,NULL,'','2018-03-16 18:20:29'),(2,'002',4,'นายแพทย์','ทดสอบ',NULL,'Test',NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'100001',NULL,NULL,'3',NULL);
/*!40000 ALTER TABLE `b_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_position`
--

DROP TABLE IF EXISTS `f_position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_position` (
  `position_id` int(11) NOT NULL AUTO_INCREMENT,
  `position_code` varchar(255) DEFAULT NULL,
  `position_name_t` varchar(255) DEFAULT NULL,
  `position_name_e` varchar(255) DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `position_active` varchar(255) DEFAULT NULL,
  `status_position` varchar(255) DEFAULT NULL COMMENT '1=staff 2= doctor',
  PRIMARY KEY (`position_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
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
  `queue_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `staff_id` varchar(255) DEFAULT NULL,
  `queue_date` varchar(255) DEFAULT NULL,
  `row_1` varchar(255) DEFAULT NULL,
  `active` varchar(255) DEFAULT NULL,
  `status_queue` varchar(255) DEFAULT NULL COMMENT '1=queue 2 = finish queue',
  `staff_name` varchar(255) DEFAULT NULL,
  `date_begin` varchar(255) DEFAULT NULL,
  `date_finish` varchar(255) DEFAULT NULL,
  `queue` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`queue_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1000000014 DEFAULT CHARSET=utf8 COMMENT='id=100';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_queue`
--

LOCK TABLES `t_queue` WRITE;
/*!40000 ALTER TABLE `t_queue` DISABLE KEYS */;
INSERT INTO `t_queue` VALUES (45,'1','2018-03-16 17:40:09','1','1','2',NULL,'2018-03-16 17:40:09','2018-03-16 17:44:20',NULL),(46,'1','2018-03-16 17:40:10','2','1','2',NULL,'2018-03-16 17:40:10','2018-03-16 17:44:38',NULL),(47,'1','2018-03-16 17:40:12','3','1','2',NULL,'2018-03-16 17:40:12','2018-03-16 17:44:46',NULL),(48,'1','2018-03-16 17:40:13','4','1','2',NULL,'2018-03-16 17:40:13','2018-03-16 17:44:58',NULL),(49,'1','2018-03-16 17:54:32','1','1','2',NULL,'2018-03-16 17:54:32','2018-03-16 17:54:42',NULL),(50,'1','2018-03-16 17:55:58','1','1','2',NULL,'2018-03-16 17:55:58','2018-03-16 17:56:42',NULL),(51,'1','2018-03-16 17:55:59','2','1','2',NULL,'2018-03-16 17:55:59','2018-03-16 17:59:32',NULL),(52,'1','2018-03-16 17:55:59','3','1','2',NULL,'2018-03-16 17:55:59','2018-03-16 18:00:33',NULL),(53,'1','2018-03-16 18:05:34','1','1','2',NULL,'2018-03-16 18:05:34','2018-03-16 18:07:47',NULL),(54,'1','2018-03-16 18:05:35','2','1','2',NULL,'2018-03-16 18:05:35','2018-03-16 18:19:57',NULL),(55,'1','2018-03-16 18:05:36','3','1','2',NULL,'2018-03-16 18:05:36','2018-03-16 18:20:09',NULL),(56,'1','2018-03-16 18:20:29','1','1','2',NULL,'2018-03-16 18:20:29','2018-03-16 18:20:34',NULL),(57,'1','2018-03-16 18:20:30','2','1','2',NULL,'2018-03-16 18:20:30','2018-03-16 18:20:44',NULL),(58,'1','2018-03-16 18:20:30','3','1','2',NULL,'2018-03-16 18:20:30','2018-03-16 18:21:28',NULL),(59,'0','','','1','','','2019-09-02 13:50:31','',NULL),(60,'0','2019-09-02 13:55:29','1','1','1','','2019-09-02 13:55:29','',NULL),(1000000000,'0','2019-09-02 13:55:56','1','1','1','','2019-09-02 13:55:56','',NULL),(1000000001,'0','2019-09-02 17:44:56','1','1','1','','2019-09-02 17:44:56','',''),(1000000002,'1','2019-09-02 18:00:11','1','1','2','','2019-09-02 18:00:11','2019-09-02 18:45:57','1'),(1000000003,'1','2019-09-02 18:00:31','1','1','2','','2019-09-02 18:00:31','2019-09-02 18:45:59','2'),(1000000004,'1','2019-09-02 18:03:15','1','1','2','','2019-09-02 18:03:15','2019-09-02 18:46:00','3'),(1000000005,'1','2019-09-02 18:03:19','1','1','2','','2019-09-02 18:03:19','2019-09-02 18:46:00','4'),(1000000006,'1','2019-09-02 18:03:42','1','1','2','','2019-09-02 18:03:42','2019-09-02 18:46:01','5'),(1000000007,'1','2019-09-02 18:06:16','1','1','2','','2019-09-02 18:06:16','2019-09-02 18:46:01','6'),(1000000008,'1','2019-09-02 18:06:19','1','1','2','','2019-09-02 18:06:19','2019-09-02 18:46:03','7'),(1000000009,'1','2019-09-02 18:06:22','1','1','2','','2019-09-02 18:06:22','2019-09-02 18:46:04','8'),(1000000010,'2','2019-09-02 18:06:37','1','1','2','','2019-09-02 18:06:37','2019-09-02 18:44:30','1'),(1000000011,'2','2019-09-02 18:06:40','1','1','2','','2019-09-02 18:06:40','2019-09-02 18:44:53','2'),(1000000012,'2','2019-09-02 18:06:43','1','1','2','','2019-09-02 18:06:43','2019-09-02 18:44:54','3'),(1000000013,'1','2019-09-02 18:09:43','1','1','2','','2019-09-02 18:09:43','2019-09-02 18:46:04','9');
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

-- Dump completed on 2019-09-02 18:47:19
