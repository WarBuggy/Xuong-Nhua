-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: ctynhua
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `paneinfo`
--

DROP TABLE IF EXISTS `paneinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paneinfo` (
  `PaneID` int(11) NOT NULL,
  `Title` varchar(200) DEFAULT '',
  `ViewQuery` varchar(2000) DEFAULT '',
  `InsertQuery` varchar(1000) DEFAULT '',
  `UpdateQuery` varchar(1000) DEFAULT '',
  `DeleteQuery` varchar(1000) DEFAULT '',
  `Comment` varchar(1000) DEFAULT '',
  `LocalName` varchar(200) DEFAULT '',
  PRIMARY KEY (`PaneID`),
  UNIQUE KEY `PaneID_UNIQUE` (`PaneID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paneinfo`
--

LOCK TABLES `paneinfo` WRITE;
/*!40000 ALTER TABLE `paneinfo` DISABLE KEYS */;
INSERT INTO `paneinfo` VALUES (5,'Partners Management','SELECT `partner`.`ID`,`partner`.`Name`,`partner`.`Description`,`partner`.`phone`, `partner`.`email`,`partner`.`Comment` FROM `ctynhua`.`partner` WHERE `partner`.`Name` LIKE CONCAT(\'%\',@NameInput,\'%\') ORDER BY `Name`','INSERT INTO `ctynhua`.`partner` (`Name`,`Description`,`phone`, `email`,`Comment`) VALUES (@NameInput, @DescInput, @PhoneInput, @EmailInput, @CommentInput);','UPDATE `ctynhua`.`partner` SET `Name` = @NameInput,`Description` = @DescInput,`Phone`=@PhoneInput, `Email`=@EmailInput,`Comment` = @CommentInput WHERE ID=@ID','DELETE FROM PARTNER WHERE ID=','','partner'),(6,'Products Management','SELECT `product`.`ID`,`product`.`Name`,`product`.`Description`, `product`.`Comment` FROM `ctynhua`.`product` WHERE `product`.`Name` LIKE CONCAT(\'%\',@NameInput,\'%\') ORDER BY `Name`','INSERT INTO `ctynhua`.`product` (`Name`,`Description`,`Comment`) VALUES (@NameInput, @DescInput, @CommentInput);','UPDATE `ctynhua`.`product` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput WHERE ID=@ID','DELETE FROM PRODUCT WHERE ID=','','product'),(7,'Materials Management','SELECT M.`ID`, M.`Name`, M.`Description`, M.`type`, T.`name`, M.`Comment` \nFROM `ctynhua`.`material` as M, `mattype` as T \nWHERE M.`Name` LIKE CONCAT(\'%\',@NameInput,\'%\') AND M.`type` = COALESCE(@TypeInput, M.`type`) \nAND M.`type` = T.`ID` \nORDER BY M.`Name`','INSERT INTO `material` (`Name`,`Description`,`Comment`,`type`) VALUES (@NameInput, @DescInput, @CommentInput,@TypeInput)','UPDATE `material` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput, `type`=@TypeInput WHERE ID=@ID','DELETE FROM material WHERE ID=','','material'),(8,'Formula Management','SELECT F.ID, F.product, P.name, F.material, M.name, F.quantity, F.Comment\n FROM formula as F,material as M, product as P\n WHERE F.material = M.ID AND F.product = P.ID\n AND F.material = COALESCE(@MaterialInput, F.material)\n AND F.product = COALESCE(@ProductInput, F.product) ORDER BY P.Name;','INSERT INTO formula (product, material, quantity, comment) VALUES (@ProductInput, @MaterialInput, @QuantityInput, @CommentInput); ','UPDATE `formula` SET product = @ProductInput, material = @MaterialInput, Quantity = @QuantityInput, Comment = @CommentInput WHERE ID=@ID','DELETE FROM formula WHERE ID=','','formula'),(9,'Material Type Management','SELECT `ID`,`Name`,`Description`,`Comment` FROM `mattype` WHERE `Name` LIKE CONCAT(\'%\',@NameInput,\'%\') ORDER BY `Name`','INSERT INTO `mattype` (`Name`,`Description`,`Comment`) VALUES (@NameInput, @DescInput, @CommentInput);','UPDATE `mattype` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput WHERE ID=@ID','DELETE FROM mattype WHERE ID=','','material type'),(10,'Materia Input Management','SELECT I.`ID`, DATE_FORMAT(I.`Date`,\'%d-%m-%y\'), I.`lot`, I.`material`, M.`name`, I.`quantity`, I.`price`, \n `price`*`quantity`/1000 as total, I.`partner`, P.`name`, I.`Comment` \n FROM `matin` as I, `material` as M, `partner` as P \n WHERE I.`material` = M.`ID` AND I.`partner` = P.`ID` \n AND I.`material` =  COALESCE(@MaterialInput, I.material)\n AND I.`partner` = COALESCE(@PartnerInput, I.partner)\n AND I.`lot` LIKE CONCAT(\'%\',@LotInput,\'%\') \n AND I.`DATE` >= @DateFrom AND I.`DATE` <= @DateUntil\n ORDER BY I.`date`','INSERT INTO matin (date, lot, material, quantity, price, partner, comment) VALUES (@DatInInput, @LotInput, @MaterialInput, @QuantityInput, @PriceInput, @PartnerInput, @CommentInput)','UPDATE `matin` SET `date`=@DatInInput,`lot`=@LotInput,`material`=@MaterialInput,`Quantity`=@QuantityInput,`price`=@PriceInput,`partner`=@PartnerInput,`Comment`=@CommentInput WHERE`ID`=@ID','DELETE FROM matin WHERE ID=','','material input'),(11,'Session Management','SELECT id, `name`, description, length, `comment` from `session` where `Name` LIKE CONCAT(\'%\',@NameInput,\'%\') ORDER BY `Name`','INSERT INTO `session` (`Name`,`Description`,`Comment`,`length`) VALUES (@NameInput, @DescInput, @CommentInput,@LengthInput)','UPDATE `session` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput, `length`=@LengthInput WHERE ID=@ID','DELETE FROM session WHERE ID=','','session'),(12,'Worker Management','SELECT id, sirname, middlename, givenname, contact, salary, comment from worker \n where sirname LIKE CONCAT(\'%\',@SirNameInput,\'%\') \n AND  givenname LIKE CONCAT(\'%\',@GivenNameInput,\'%\') ORDER BY `givenname`','INSERT INTO `worker` (`sirname`,`middlename`,`givenname`,`contact`,`salary`,`comment`) VALUES \n (@SirNameInput,@MiddleNameInput,@GivenNameInput,@ContactInput,@SalaryInput,@CommentInput)','UPDATE `worker` SET `sirname` = @SirNameInput,`middlename`=@MiddleNameInput,`givenname`=@GivenNameInput,`contact`=@ContactInput,`salary`=@SalaryInput,`comment`=@CommentInput WHERE `id`=@ID;','DELETE FROM worker WHERE ID=','','worker'),(13,'Production Management','SELECT P.`ID`, DATE_FORMAT(P.`Date`,\'%d-%m-%y\'), P.`session`, S.`name`, P.`worker`,\n   CONCAT (W.`sirname`, \' \', W.`middlename`, \' \', W.`givenname`) as `fullname`,\n   P.`product`, D.`Name`, P.`quantity`, P.`Comment`\n   FROM `production` as P, `worker` as W, `product` as D, `session` as S\n   WHERE P.`product`=D.`ID` AND P.`worker`=W.`id` AND P.`session`=S.`id`\n   AND P.`worker`=COALESCE(@WorkerInput, P.`worker`)\n   AND P.`product`=COALESCE(@ProductInput, P.`product`)\n   AND P.`DATE` >= @DateFrom AND P.`DATE` <= @DateUntil\n   ORDER BY P.`date`','INSERT INTO `production`(`date`,`session`,`worker`,`product`,`quantity`,`Comment`) VALUES\n (@DateInput, @SessionInput, @WorkerInput, @ProductInput, @QuantityInput, @CommentInput)','UPDATE `production` SET `date` = @DateInput, `session` = @SessionInput, `worker` = @WorkerInput,\n `product` = @ProductInput, `quantity` = @QuantityInput, `Comment` = @CommentInput WHERE `ID` = @ID','DELETE FROM production WHERE ID=','','production'),(14,'Material Inventory Management','SELECT * FROM (\n \n SELECT I.`ID`,  DATE_FORMAT(I.`Date`,\'%d-%m-%y\') as `date`, I.`lot`, I.`material`, M.`name`, \n  coalesce(I.`quantity`, 0) as quantity,\n  coalesce(sum(O.`quantity`), 0) as output,\n  coalesce(I.`quantity`-sum(O.`quantity`), 0) as remaining, \n  coalesce(I.`price`, 0) as price, I.`comment`\n  FROM matin as I, material as M, matout as O\n  WHERE I.`material`=M.`id` \n  AND I.`material`=COALESCE(@MaterialInput, I.`material`)\n  AND I.`id`=O.`inid` \n  AND I.`lot` LIKE CONCAT(\'%\',@LotInput,\'%\') \n  AND I.`DATE`>=@DateFrom AND I.`DATE`<=@DateUntil\n  GROUP BY I.id\n  \n  UNION \n  \n SELECT I.`ID`,  DATE_FORMAT(I.`Date`,\'%d-%m-%y\') as `date`, I.`lot`, I.`material`, M.`name`, I.`quantity`,\n  0 as output,\n  I.`quantity` as remaining, \n  I.`price`, I.`comment`\n  FROM matin as I, material as M, matout as O\n  WHERE I.`material`=M.`ID` \n  AND I.`material`=COALESCE(@MaterialInput, I.`material`)\n  AND I.`id`NOT IN (SELECT `inid` FROM `matout`) \n  AND I.`lot` LIKE CONCAT(\'%\',@LotInput,\'%\') \n  AND I.`DATE`>=@DateFrom AND I.`DATE`<=@DateUntil\n  GROUP BY I.`id`) as T WHERE id IS NOT NULL \n  ORDER BY `date`;\n ',' ','INSERT INTO `matout` (`date`,`inid`,`quantity`,`production`,`comment`) VALUES (@DateInput,@InIDInput,@QuantityInput,@ProductionInput,@CommentInput)',' ','','material output');
/*!40000 ALTER TABLE `paneinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-02  0:34:43
