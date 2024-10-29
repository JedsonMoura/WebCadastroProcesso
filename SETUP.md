- **Processo seletivo FSBR**

- **Sistema Operacional:** (Windows)
- **Banco de Dados:** (MySQL)

## Instalação das Dependências
- **Dependências:** (Microsoft.AspNetCore.App                               6.0.35       6.0.35 
                    > Microsoft.EntityFrameworkCore                         6.0.35       6.0.35   
                    > Microsoft.EntityFrameworkCore.Design                  6.0.35       6.0.35      
                    > MySql.EntityFrameworkCore                             6.0.33       6.0.33   
                    > Pomelo.EntityFrameworkCore.MySql                      6.0.3        6.0.3    
                    > Pomelo.EntityFrameworkCore.MySql.Design               1.1.2        1.1.2)

1. **Clone o Repositório**
   git clone https://github.com/JedsonMoura/WebCadastroProcesso.git


2. **Script banco**
    criação base:
        create database fsbr

    criação tabela processo:
    -- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fsbr
-- ------------------------------------------------------
-- Server version	8.4.1

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
-- Dumping data for table `processo`
--

LOCK TABLES `processo` WRITE;
/*!40000 ALTER TABLE `processo` DISABLE KEYS */;
INSERT INTO `processo` VALUES (5,'fsfs','7878777-77.7777.77.7777','2024-10-11 19:36:00.000000','2024-10-29 08:59:14.726731','PB','Muquém'),(6,'fsfs','7878777-77.7777.77.7777','2024-10-05 19:43:00.000000','2024-10-29 13:04:51.850450','PB','Mata Limpa'),(7,'Processo Criminal 123','7878777-77.7777.77.7777','2024-10-09 19:43:00.000000','2024-10-09 19:43:00.000000','PB','Mata Limpa'),(8,'Processo Criminal 123','7878777-77.7777.77.7777','2024-10-28 19:51:02.940097','2024-10-29 11:32:18.754968','AP','Sucuriju'),(9,'jedson de moura tenorio','7878777-77.7777.77.7777','2024-10-28 19:52:09.165945','2024-10-28 19:52:09.165947','AC','Acrelândia'),(11,'fsfsfsfs','4544444-44.4444.44.4444','2024-10-28 19:52:37.589954','2024-10-28 19:52:37.589956','AL','Anadia'),(12,'jedson de moura tenorio','7878777-77.7777.77.7777','2024-10-28 19:53:56.941949','2024-10-29 13:04:21.522260','AM','Apuí'),(13,'Processo Criminal 123dfsfgs','7878777-77.7777.77.7777','2024-10-29 13:11:51.125685','0001-01-01 00:00:00.000000','AC','Amaturá'),(14,'jedson de moura tenorio','7878777-77.7777.77.7777','2024-10-28 21:02:35.300647','0001-01-01 00:00:00.000000','AL','Arapiraca'),(15,'jedson de moura tenorio','7878777-77.7777.77.7777','2024-10-28 22:10:06.915200','0001-01-01 00:00:00.000000','PI','Avelino Lopes'),(16,'fsfs','7878777-77.7777.77.7777','2024-10-28 22:51:06.137404','0001-01-01 00:00:00.000000','PI','Barra D\'Alcântara'),(17,'Processo Criminal 123dfsfgs','7878777-77.7777.77.7777','2024-10-28 23:53:47.997363','0001-01-01 00:00:00.000000','PI','Baixa Grande do Ribeiro'),(18,'testeEmPROD tenorio','4444444-44.4444.44.4444','2024-10-29 08:56:05.332460','2024-10-29 13:08:35.200884','CE','Acaraú'),(19,'FSBR','0000000-00.0000.00.0000','2024-10-29 13:08:22.772861','2024-10-29 13:14:54.182639','AP','Carvão');
/*!40000 ALTER TABLE `processo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

