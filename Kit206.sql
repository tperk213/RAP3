-- MariaDB dump 10.19  Distrib 10.4.20-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: kit206
-- ------------------------------------------------------
-- Server version	10.4.20-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `position`
--

DROP TABLE IF EXISTS `position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `position` (
  `id` int(11) NOT NULL,
  `level` enum('A','B','C','D','E') NOT NULL,
  `start` date NOT NULL,
  `end` date DEFAULT NULL,
  PRIMARY KEY (`id`,`level`,`start`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `position`
--

LOCK TABLES `position` WRITE;
/*!40000 ALTER TABLE `position` DISABLE KEYS */;
INSERT INTO `position` VALUES (123460,'B','2010-06-17',NULL),(123461,'A','2006-01-19','2010-02-16'),(123461,'B','2010-02-17','2013-12-31'),(123461,'C','2014-01-01',NULL),(123462,'A','2011-01-10','2012-04-15'),(123462,'B','2012-04-16',NULL),(123463,'B','2012-01-28',NULL),(123464,'B','2007-01-19','2011-03-13'),(123464,'C','2011-03-14','2014-04-11'),(123464,'D','2014-04-12',NULL),(123465,'A','2014-05-23',NULL);
/*!40000 ALTER TABLE `position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publication`
--

DROP TABLE IF EXISTS `publication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `publication` (
  `doi` varchar(256) NOT NULL,
  `title` varchar(256) NOT NULL,
  `authors` varchar(256) NOT NULL,
  `year` year(4) NOT NULL,
  `type` enum('Conference','Journal','Other') NOT NULL,
  `cite_as` varchar(1024) NOT NULL,
  `available` date NOT NULL,
  PRIMARY KEY (`doi`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publication`
--

LOCK TABLES `publication` WRITE;
/*!40000 ALTER TABLE `publication` DISABLE KEYS */;
INSERT INTO `publication` VALUES ('10.1007/11504894_31','Structural advantages for ant colony optimisation inherent in permutation scheduling problems','Alexandra Halloran, Gemma Stanford',2017,'Conference','Halloran, A and Stanford, G, \"Structural advantages for ant colony optimisation inherent in permutation scheduling problems\", Proceedings 18th International Conference on Industrial and Engineering Applications of Artificial Intelligence and Expert Systems (IEA/AIE 2011), 22-24 June 2011, Bari, Italy, pp. 218-228. (2011)','2017-07-13'),('10.1007/11839088_42','Higher order pheromone models in ant colony optimisation','Ben Bramston, Caitlyn Pemulwuy',2018,'Conference','Bramston, B and Pemulwuy, C, \"Higher order pheromone models in ant colony optimisation\", Proceedings 5th International Workshop on Ant Colony Optimization and Swarm Intelligence (ANTS 2012), 4-7 September 2012, Brussels, Belgium, pp. 428-435. (2012)','2018-09-12'),('10.1007/11839088_49','Solution representation for job shop scheduling problems in ant colony optimisation','Mary Lister',2018,'Conference','Lister, M, \"Solution representation for job shop scheduling problems in ant colony optimisation\", Proceedings Fifth International Workshop on Ant Colony Optimization and Swarm Intelligence (ANTS 2012), 4-7 September 2012, Brussels, Belgium, pp. 484-491. (2012)','2018-01-27'),('10.1007/3-540-45724-0_22','Candidate set strategies for ant colony optimisation','Mary Lister',2016,'Conference','Lister, M, \"Candidate set strategies for ant colony optimisation\", Proceedings 3rd International Workshop on Ant Algorithms (ANTS 2010), 12-14 September 2010, Brussels, Belgium, pp. 243-249. (2010)','2016-01-20'),('10.1007/3-540-45724-0_9','Anti-pheromone as a tool for better exploration of search space','Gemma Stanford',2017,'Conference','Stanford, G, \"Anti-pheromone as a tool for better exploration of search space\", Proceedings 3rd International Workshop on Ant Algorithms (ANTS 2011), 12-14 September 2011, Brussels, Belgium, pp. 100-110. (2011)','2017-12-03'),('10.1007/978-3-540-76931-6_1','Alternative solution representations for the job shop scheduling problem in ant colony optimisation','Gemma Stanford, John Beckett',2018,'Conference','Stanford, G and Beckett, J, \"Alternative solution representations for the job shop scheduling problem in ant colony optimisation\", Proceedings Third Australian Conference on Artificial Life (ACAL07), 4-6 December 2012, Gold Coast, Australia, pp. 1-12. (2012)','2018-07-21'),('10.1007/978-3-642-10427-5_27','The effects of different kinds of move in differential evolution searches','Caitlyn Pemulwuy',2018,'Conference','Pemulwuy, C, \"The effects of different kinds of move in differential evolution searches\", Artificial Life: Borrowing from Biology, 1-4 December 2012, Melbourne, Australia, pp. 272-281. (2012)','2018-02-14'),('10.1007/978-3-642-25832-9_29','A simple strategy to maintain diversity and reduce crowding in particle swarm optimization','Alexandra Halloran',2019,'Conference','Halloran, A, \"A simple strategy to maintain diversity and reduce crowding in particle swarm optimization\", AI 2013: Advances in Artificial Intelligence, 5-8 December 2013, Perth, Australia, pp. 281-290. (2013)','2019-05-29'),('10.1007/b99492','Search bias in constructive metaheuristics and implications for ant colony optimisation','John Beckett',2017,'Conference','Beckett, J, \"Search bias in constructive metaheuristics and implications for ant colony optimisation\", Proceedings of the 4th International Workshop (ANTS 2011), 5-8 September 2011, Brussels, Belgium, pp. 390-397. (2011)','2017-11-25'),('10.1007/s10489-014-0613-2','Measuring the curse of dimensionality and its effects on particle swarm optimization and differential evolution','Gemma Stanford',2021,'Journal','Stanford, G, \"Measuring the curse of dimensionality and its effects on particle swarm optimization and differential evolution\", Applied Intelligence, 42(3), pp. 514-526. (2015)','2021-08-04'),('10.1016/j.cor.2006.12.014','Solution bias in ant colony optimisation: lessons for selecting pheromone models','Edward Vogt, Gemma Stanford',2020,'Journal','Vogt, E and Stanford, G, \"Solution bias in ant colony optimisation: lessons for selecting pheromone models\", Computers and Operations Research, 35(9), pp. 2728-2749. (2014)','2020-11-07'),('10.1016/j.procs.2014.05.174','Extending the front: designing RFID antennas using multiobjective differential evolution with biased population selection','Gemma Stanford',2021,'Conference','Stanford, G, \"Extending the front: designing RFID antennas using multiobjective differential evolution with biased population selection\", Proceedings of 14th International Conference on Computational Science 2015, 10-12 June 2015, Cairns, Australia, pp. 1893-1903. (2015)','2021-08-14'),('10.1109/CEC.2009.4983298','Differential evolution: difference vectors and movement in solution space','Alexandra Halloran, Gemma Stanford',2018,'Conference','Halloran, A and Stanford, G, \"Differential evolution: difference vectors and movement in solution space\", Proceedings of the IEEE Congress on Evolutionary Computation 2012, 18-21 May 2012, Trondheim, Norway, pp. 2833-2840. (2012)','2018-02-14'),('10.1109/CEC.2010.5586128','An analysis of the operation of differential evolution at high and low crossover rates','Caitlyn Pemulwuy',2018,'Conference','Pemulwuy, C, \"An analysis of the operation of differential evolution at high and low crossover rates\", Proceedings of the IEEE Congress on Evolutionary Computation 2012, 18-23 July 2012, Barcelona, Spain, pp. 1807-1814. (2012)','2018-08-04'),('10.1109/CEC.2010.5586184','Crossover and the different faces of differential evolution searches','Caitlyn Pemulwuy, Gemma Stanford',2018,'Conference','Pemulwuy, C and Stanford, G, \"Crossover and the different faces of differential evolution searches\", Proceedings of the IEEE Congress on Evolutionary Computation 2012, 18-23 July 2012, Barcelona, Spain, pp. 1951-1958. (2012)','2018-04-22'),('10.1109/CEC.2012.6252891','A simple strategy for maintaining diversity and reducing crowding in differential evolution','Ben Bramston, Caitlyn Pemulwuy',2019,'Conference','Bramston, B and Pemulwuy, C, \"A simple strategy for maintaining diversity and reducing crowding in differential evolution\", Proceedings of 2013 IEEE Congress on Evolutionary Computation, 10-15 June 2013, Brisbane, Australia, pp. 2692-2699. (2013)','2019-08-05'),('10.1109/CEC.2012.6252923','Improving exploration in ant colony optimisation with antennation','Mary Lister, Gemma Stanford',2019,'Conference','Lister, M and Stanford, G, \"Improving exploration in ant colony optimisation with antennation\", 2013 IEEE Congress on Evolutionary Computation, 10-15 June 2013, Brisbane, Australia, pp. 2926-2933. (2013)','2019-05-04'),('10.1109/CEC.2012.6256591','Simulated annealing with thresheld convergence','Gemma Stanford',2019,'Conference','Stanford, G, \"Simulated annealing with thresheld convergence\", Proceedings of 2013 IEEE Congress on Evolutionary Computation, 2013 IEEE Congress on Evolutionary Computation, Brisbane, Australia, pp. 1946-1952. (2013)','2019-02-13'),('10.1109/CEC.2013.6557551','Differential evolution with thresheld convergence','Charlie Byrnes, Gemma Stanford',2020,'Conference','Byrnes, C and Stanford, G, \"Differential evolution with thresheld convergence\", Proceedings of 2014 IEEE Congress on Evolutionary Computation, 20-23 June 2013, Cancun, Mexico, pp. 40-47. (2014)','2020-02-03'),('10.1109/CEC.2013.6557611','Particle swarm optimization with thresheld convergence','Caitlyn Pemulwuy',2020,'Conference','Pemulwuy, C, \"Particle swarm optimization with thresheld convergence\", Proceedings of 2014 IEEE Congress on Evolutionary Computation, 20-23 June 2013, Cancun, Mexico, pp. 510-516. (2014)','2020-05-22'),('10.1109/CEC.2014.6900579','Identifying and exploiting the scale of a search space in differential evolution','Holly Pell, Edward Vogt',2021,'Conference','Pell, H and Vogt, E, \"Identifying and exploiting the scale of a search space in differential evolution\", Proceedings of 2014 IEEE Congress on Evolutionary Computation, 6-11 July 2015, Beijing, China, pp. 1427-1434. (2015)','2021-02-06'),('10.1109/eScienceW.2010.26','Parallel constraint handling in a multiobjective evolutionary algorithm for the automotive deployment problem','Gemma Stanford, Edward Vogt, Alexandra Halloran',2018,'Conference','Stanford, G and Vogt, E and Halloran, A, \"Parallel constraint handling in a multiobjective evolutionary algorithm for the automotive deployment problem\", Proceedings of the 6th IEEE International Conference on E-Science Workshops 2012, 7-10 December 2012, Brisbane, Australia, pp. 104-109. (2012)','2018-12-28'),('10.1109/ISDA.2013.6920726','Hybridization of particle swarm optimization with adaptive genetic algorithm operators','Gemma Stanford, Edward Vogt, Caitlyn Pemulwuy',2020,'Conference','Stanford, G and Vogt, E and Pemulwuy, C, \"Hybridization of particle swarm optimization with adaptive genetic algorithm operators\", Proceedings of the 2014 International Conference on Intelligent Systems Design and Applications, 8-10 December 2013, Malaysia, pp. 1-6. (2014)','2020-10-05'),('10.1109/TALE.2013.6654527','Agile development spikes applied to computer science education','Indiana Whitta, Caitlyn Pemulwuy',2020,'Conference','Whitta, I and Pemulwuy, C, \"Agile development spikes applied to computer science education\", Proceedings of IEEE International Conference on Teaching, Assessment and Learning for Engineering 2014, 26-29 August 2014, Kuta, Indonesia, pp. 699-704. (2014)','2020-09-07'),('10.1142/S1469026803000938','The accumulated experience ant colony for the travelling salesman problem','Caitlyn Pemulwuy',2017,'Journal','Pemulwuy, C, \"The accumulated experience ant colony for the travelling salesman problem\", International Journal of Computational Intelligence and Applications, 3(2), pp. 189-198. (2011)','2017-09-27'),('10.1145/2001576.2001585','Selection strategies for initial positions and initial velocities in multi-optima particle swarms','Ben Bramston, Caitlyn Pemulwuy, Alexandra Halloran',2019,'Conference','Bramston, B and Pemulwuy, C and Halloran, A, \"Selection strategies for initial positions and initial velocities in multi-optima particle swarms\", Proceedings of the 13th Annual Conference on Genetic and Evolutionary Computation, 12-16 July 2013, Dublin, Ireland, pp. 53-60. (2013)','2019-11-10'),('10.1145/2001576.2001669','Differential evolution for RFID antenna design: a comparison with ant colony optimisation','Gemma Stanford',2019,'Conference','Stanford, G, \"Differential evolution for RFID antenna design: a comparison with ant colony optimisation\", Proceedings of the 13th Annual Conference on Genetic and Evolutionary Computation, 12-16 July 2013, Dublin, Ireland, pp. 673-680. (2013)','2019-04-22'),('10.1145/2001576.2001682','Population-ACO for the automotive deployment problem','Mary Lister',2019,'Conference','Lister, M, \"Population-ACO for the automotive deployment problem\", Proceedings of the 13th Annual Conference on Genetic and Evolutionary Computation, 12-16 July 2013, Dublin, Ireland, pp. 777-784. (2013)','2019-07-02'),('10.1162/1064546054407149','Automated selection of appropriate pheromone representations in ant colony optimization','Alexandra Halloran, Gemma Stanford',2018,'Journal','Halloran, A and Stanford, G, \"Automated selection of appropriate pheromone representations in ant colony optimization\", Artificial Life, 11(3), pp. 269-291. (2012)','2018-08-16'),('prefix/sample1','Protocols and structures for inference: a RESTful API for machine learning','Indiana Whitta',2021,'Conference','Whitta, I, \"Protocols and structures for inference: a RESTful API for machine learning\", Proceedings of the 2nd Conference on Predictive APIs and Apps, 6-7 August 2015, Sydney, Australia, pp. 1-8. (2015)','2021-10-11'),('prefix/sample10','Storing and retrieving software components: a component description manager','Caitlyn Pemulwuy, Gemma Stanford',2016,'Conference','Pemulwuy, C and Stanford, G, \"Storing and retrieving software components: a component description manager\", Proceedings 12th Australian Software Engineering Conference (ASWEC 2010), 28-29 April 2010, Canberra, ACT, pp. 107-117. (2010)','2016-11-28'),('prefix/sample11','Solution biases and pheromone representation selection in ant colony optimisation','Gemma Stanford',2011,'Other','Stanford, G, \"Solution biases and pheromone representation selection in ant colony optimisation\"  (2005)','2011-03-28'),('prefix/sample2','Representation matters: real-valued encodings for meander line RFID antennas','Charlie Byrnes, Gemma Stanford',2021,'Conference','Byrnes, C and Stanford, G, \"Representation matters: real-valued encodings for meander line RFID antennas\", Proceedings of 2015 IEEE Congress on Evolutionary Computation, 25-28 May, Sendai, Japan, pp. 1303-1310. (2015)','2021-07-12'),('prefix/sample3','Evolution strategies with thresheld convergence','Caitlyn Pemulwuy',2021,'Conference','Pemulwuy, C, \"Evolution strategies with thresheld convergence\", Proceedings of 2015 IEEE Congress on Evolutionary Computation, 25-28 May, Sendai, Japan, pp. 2097-2104. (2015)','2021-10-26'),('prefix/sample4','A framework for integrating concept maps into higher-order learning units in IT education','Alexandra Halloran',2021,'Conference','Halloran, A, \"A framework for integrating concept maps into higher-order learning units in IT education\", Workshop on HCI Education in Asia Pacific at OzCHI, 2 December, Sydney, Australia, pp. 7-10. (2015)','2021-07-06'),('prefix/sample5','Towards the effective use of multiple displays in teaching and learning environments','Gemma Stanford',2020,'Conference','Stanford, G, \"Towards the effective use of multiple displays in teaching and learning environments\", Workshop on HCI Education in Asia Pacific at OzCHI, 2 December, Sydney, Australia, pp. 21-24. (2014)','2020-04-15'),('prefix/sample6','Anatomy of a learning problem','Edward Vogt, Caitlyn Pemulwuy',2018,'Conference','Vogt, E and Pemulwuy, C, \"Anatomy of a learning problem\", Proceedings of the 25th Conference on Neural Information Processing Systems, 16-17 December 2012, Sierra Nevada,Spain, pp. 1-8. (2012)','2018-11-24'),('prefix/sample7','Semi-formal, not semi-realistic: a component description manager','Caitlyn Pemulwuy',2017,'Conference','Pemulwuy, C, \"Semi-formal, not semi-realistic: a component description manager\", Proceedings Technology of Object-Oriented Languages, Systems and Architectures, 13-15 March 2011, Sofia, Bulgaria, pp. 197-207. (2011)','2017-10-11'),('prefix/sample8','Automated selection of appropriate pheromone representations in ant colony optimisation','John Beckett',2017,'Conference','Beckett, J, \"Automated selection of appropriate pheromone representations in ant colony optimisation\", Proceedings 1st Australian Conference on Artificial Life (ACAL 2011), 6-7 December 2011, Canberra, ACT, pp. 170-184. (2011)','2017-12-20'),('prefix/sample9','The accumulated experience ant colony for the travelling salesman problem','John Beckett',2016,'Conference','Beckett, J, \"The accumulated experience ant colony for the travelling salesman problem\", Proceedings of the Inaugural Workshop on Artificial Life (AL 01), 11 December 2010, Adelaide, South Australia, pp. 79-87. (2010)','2016-06-10');
/*!40000 ALTER TABLE `publication` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researcher`
--

DROP TABLE IF EXISTS `researcher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `researcher` (
  `id` int(11) NOT NULL,
  `type` enum('Staff','Student') NOT NULL,
  `given_name` varchar(20) NOT NULL,
  `family_name` varchar(20) NOT NULL,
  `title` varchar(10) NOT NULL,
  `unit` varchar(64) NOT NULL,
  `campus` enum('Hobart','Launceston','Cradle Coast') NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `photo` varchar(512) DEFAULT NULL,
  `degree` varchar(16) DEFAULT NULL,
  `supervisor_id` int(11) DEFAULT NULL,
  `level` enum('A','B','C','D','E') DEFAULT NULL,
  `utas_start` date DEFAULT NULL,
  `current_start` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_researcher_researcher1` (`supervisor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researcher`
--

LOCK TABLES `researcher` WRITE;
/*!40000 ALTER TABLE `researcher` DISABLE KEYS */;
INSERT INTO `researcher` VALUES (123460,'Staff','John','Beckett','Dr','Engineering & ICT','Hobart','no.such.email@example.org','pexels-photo-2379004.jpeg',NULL,NULL,'B','2010-06-17','2010-06-17'),(123461,'Staff','Gemma','Stanford','Dr','Engineering & ICT','Launceston','no.such.email@example.org','pexels-photo-1181521.jpeg',NULL,NULL,'C','2006-01-19','2014-01-01'),(123462,'Staff','Edward','Vogt','Dr','Engineering & ICT','Hobart','no.such.email@example.org','pexels-photo-834863.jpeg',NULL,NULL,'B','2011-01-10','2012-04-16'),(123463,'Staff','Mary','Lister','Dr','TIA','Hobart','no.such.email@example.org','pexels-photo-3765175.jpeg',NULL,NULL,'B','2012-01-28','2012-01-28'),(123464,'Staff','Caitlyn','Pemulwuy','Dr','TIA','Hobart','no.such.email@example.org','pexels-photo-1987301.jpeg',NULL,NULL,'D','2007-01-19','2014-04-12'),(123465,'Staff','Indiana','Whitta','Dr','TIA','Cradle Coast','no.such.email@example.org','pexels-photo-2777898.jpeg',NULL,NULL,'A','2014-05-23','2014-05-23'),(123466,'Student','Alexandra','Halloran','Ms','Engineering & ICT','Hobart','no.such.email@example.org','pexels-photo-2346754.jpeg','PhD',123461,NULL,'2011-08-31','2011-08-31'),(123467,'Student','Charlie','Byrnes','Mr','Engineering & ICT','Hobart','no.such.email@example.org','pexels-photo-927022.jpeg','PhD',123461,NULL,'2013-04-24','2013-04-24'),(123468,'Student','Holly','Pell','Ms','Engineering & ICT','Launceston','no.such.email@example.org','pexels-photo-3294237.jpeg','PhD',123462,NULL,'2014-08-23','2014-08-23'),(123469,'Student','Ben','Bramston','Mr','TIA','Hobart','no.such.email@example.org','pexels-photo-1587014.jpeg','MSc',123464,NULL,'2011-03-16','2011-03-16');
/*!40000 ALTER TABLE `researcher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researcher_publication`
--

DROP TABLE IF EXISTS `researcher_publication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `researcher_publication` (
  `researcher_id` int(11) NOT NULL,
  `doi` varchar(256) NOT NULL,
  PRIMARY KEY (`researcher_id`,`doi`),
  KEY `fk_researcher_has_publication_publication1` (`doi`),
  CONSTRAINT `fk_researcher_has_publication_publication1` FOREIGN KEY (`doi`) REFERENCES `publication` (`doi`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_researcher_has_publication_researcher1` FOREIGN KEY (`researcher_id`) REFERENCES `researcher` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researcher_publication`
--

LOCK TABLES `researcher_publication` WRITE;
/*!40000 ALTER TABLE `researcher_publication` DISABLE KEYS */;
INSERT INTO `researcher_publication` VALUES (123460,'10.1007/978-3-540-76931-6_1'),(123460,'10.1007/b99492'),(123460,'prefix/sample8'),(123460,'prefix/sample9'),(123461,'10.1007/11504894_31'),(123461,'10.1007/3-540-45724-0_9'),(123461,'10.1007/978-3-540-76931-6_1'),(123461,'10.1007/s10489-014-0613-2'),(123461,'10.1016/j.cor.2006.12.014'),(123461,'10.1016/j.procs.2014.05.174'),(123461,'10.1109/CEC.2009.4983298'),(123461,'10.1109/CEC.2010.5586184'),(123461,'10.1109/CEC.2012.6252923'),(123461,'10.1109/CEC.2012.6256591'),(123461,'10.1109/CEC.2013.6557551'),(123461,'10.1109/eScienceW.2010.26'),(123461,'10.1109/ISDA.2013.6920726'),(123461,'10.1145/2001576.2001669'),(123461,'10.1162/1064546054407149'),(123461,'prefix/sample10'),(123461,'prefix/sample11'),(123461,'prefix/sample2'),(123461,'prefix/sample5'),(123462,'10.1016/j.cor.2006.12.014'),(123462,'10.1109/CEC.2014.6900579'),(123462,'10.1109/eScienceW.2010.26'),(123462,'10.1109/ISDA.2013.6920726'),(123462,'prefix/sample6'),(123463,'10.1007/11839088_49'),(123463,'10.1007/3-540-45724-0_22'),(123463,'10.1109/CEC.2012.6252923'),(123463,'10.1145/2001576.2001682'),(123464,'10.1007/11839088_42'),(123464,'10.1007/978-3-642-10427-5_27'),(123464,'10.1109/CEC.2010.5586128'),(123464,'10.1109/CEC.2010.5586184'),(123464,'10.1109/CEC.2012.6252891'),(123464,'10.1109/CEC.2013.6557611'),(123464,'10.1109/ISDA.2013.6920726'),(123464,'10.1109/TALE.2013.6654527'),(123464,'10.1142/S1469026803000938'),(123464,'10.1145/2001576.2001585'),(123464,'prefix/sample10'),(123464,'prefix/sample3'),(123464,'prefix/sample6'),(123464,'prefix/sample7'),(123465,'10.1109/TALE.2013.6654527'),(123465,'prefix/sample1'),(123466,'10.1007/11504894_31'),(123466,'10.1007/978-3-642-25832-9_29'),(123466,'10.1109/CEC.2009.4983298'),(123466,'10.1109/eScienceW.2010.26'),(123466,'10.1145/2001576.2001585'),(123466,'10.1162/1064546054407149'),(123466,'prefix/sample4'),(123467,'10.1109/CEC.2013.6557551'),(123467,'prefix/sample2'),(123468,'10.1109/CEC.2014.6900579'),(123469,'10.1007/11839088_42'),(123469,'10.1109/CEC.2012.6252891'),(123469,'10.1145/2001576.2001585');
/*!40000 ALTER TABLE `researcher_publication` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-16 12:06:00
