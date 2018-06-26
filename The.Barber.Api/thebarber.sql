-- phpMyAdmin SQL Dump
-- version 4.8.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 26, 2018 at 06:21 AM
-- Server version: 10.1.31-MariaDB
-- PHP Version: 7.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mydb`
--
CREATE DATABASE IF NOT EXISTS `mydb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `mydb`;

-- --------------------------------------------------------

--
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
CREATE TABLE `agendamento` (
  `cliente_id_cliente` int(11) NOT NULL,
  `barbeiro_id_barbeiro` int(11) NOT NULL,
  `horario` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `RoleId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `UserId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers` (
  `Id` varchar(127) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `BarbeiroId` int(11) DEFAULT NULL,
  `ClienteId` int(11) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `avaliacao`
--

DROP TABLE IF EXISTS `avaliacao`;
CREATE TABLE `avaliacao` (
  `id_avaliacao` int(11) NOT NULL,
  `agendamento_cliente_id_cliente` int(11) NOT NULL,
  `agendamento_barbeiro_id_barbeiro` int(11) NOT NULL,
  `nota_barbeiro` int(11) NOT NULL,
  `nota_cliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `barbearia`
--

DROP TABLE IF EXISTS `barbearia`;
CREATE TABLE `barbearia` (
  `id_barbearia` int(11) NOT NULL,
  `Bairro` varchar(45) NOT NULL,
  `cidades_id_cidade` int(11) NOT NULL,
  `cnpj` varchar(14) NOT NULL,
  `Complemento` varchar(45) DEFAULT NULL,
  `logradouro` varchar(45) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `numero` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `barbeiro`
--

DROP TABLE IF EXISTS `barbeiro`;
CREATE TABLE `barbeiro` (
  `id_barbeiro` int(11) NOT NULL,
  `Bairro` varchar(45) NOT NULL,
  `barbeirocol` varchar(45) DEFAULT NULL,
  `Complemento` varchar(45) DEFAULT NULL,
  `cpf` varchar(11) NOT NULL,
  `logradouro` varchar(45) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `numero` int(11) DEFAULT NULL,
  `UsuarioId` varchar(127) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cidade`
--

DROP TABLE IF EXISTS `cidade`;
CREATE TABLE `cidade` (
  `id_cidade` int(11) NOT NULL,
  `estados_id_estado` int(11) NOT NULL,
  `nome` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente` (
  `id_cliente` int(11) NOT NULL,
  `bairro` varchar(45) NOT NULL,
  `cep` varchar(45) NOT NULL,
  `cidades_id_cidade` int(11) NOT NULL,
  `cpf` varchar(11) NOT NULL,
  `email` varchar(45) NOT NULL,
  `logradouro` varchar(45) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `numero` varchar(45) NOT NULL,
  `UsuarioId` varchar(127) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `corte`
--

DROP TABLE IF EXISTS `corte`;
CREATE TABLE `corte` (
  `id_corte` int(11) NOT NULL,
  `cortecol` varchar(45) DEFAULT NULL,
  `foto` varchar(45) DEFAULT NULL,
  `nome` varchar(45) NOT NULL,
  `valor` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `corte_por_barbeiro`
--

DROP TABLE IF EXISTS `corte_por_barbeiro`;
CREATE TABLE `corte_por_barbeiro` (
  `corte_id_corte` int(11) NOT NULL,
  `barbeiro_id_barbeiro` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `estado`
--

DROP TABLE IF EXISTS `estado`;
CREATE TABLE `estado` (
  `id_estado` int(11) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `uf` varchar(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `funcionarios`
--

DROP TABLE IF EXISTS `funcionarios`;
CREATE TABLE `funcionarios` (
  `barbearia_id_barbearia` int(11) NOT NULL,
  `barbeiro_id_barbeiro` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20180624161729_Init', '2.0.3-rtm-10026');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agendamento`
--
ALTER TABLE `agendamento`
  ADD PRIMARY KEY (`cliente_id_cliente`,`barbeiro_id_barbeiro`),
  ADD KEY `fk_cliente_has_barbeiro_barbeiro1_idx` (`barbeiro_id_barbeiro`),
  ADD KEY `fk_cliente_has_barbeiro_cliente1_idx` (`cliente_id_cliente`);

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `avaliacao`
--
ALTER TABLE `avaliacao`
  ADD PRIMARY KEY (`id_avaliacao`,`agendamento_cliente_id_cliente`,`agendamento_barbeiro_id_barbeiro`),
  ADD KEY `fk_avaliacao_agendamento1_idx` (`agendamento_cliente_id_cliente`,`agendamento_barbeiro_id_barbeiro`);

--
-- Indexes for table `barbearia`
--
ALTER TABLE `barbearia`
  ADD PRIMARY KEY (`id_barbearia`),
  ADD KEY `fk_barbearias_cidades1_idx` (`cidades_id_cidade`);

--
-- Indexes for table `barbeiro`
--
ALTER TABLE `barbeiro`
  ADD PRIMARY KEY (`id_barbeiro`),
  ADD UNIQUE KEY `IX_barbeiro_UsuarioId` (`UsuarioId`);

--
-- Indexes for table `cidade`
--
ALTER TABLE `cidade`
  ADD PRIMARY KEY (`id_cidade`),
  ADD KEY `fk_cidades_estados1_idx` (`estados_id_estado`);

--
-- Indexes for table `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`id_cliente`),
  ADD UNIQUE KEY `IX_cliente_UsuarioId` (`UsuarioId`),
  ADD KEY `fk_cliente_cidades_idx` (`cidades_id_cidade`);

--
-- Indexes for table `corte`
--
ALTER TABLE `corte`
  ADD PRIMARY KEY (`id_corte`);

--
-- Indexes for table `corte_por_barbeiro`
--
ALTER TABLE `corte_por_barbeiro`
  ADD PRIMARY KEY (`corte_id_corte`,`barbeiro_id_barbeiro`),
  ADD KEY `fk_corte_has_barbeiro_barbeiro1_idx` (`barbeiro_id_barbeiro`),
  ADD KEY `fk_corte_has_barbeiro_corte1_idx` (`corte_id_corte`);

--
-- Indexes for table `estado`
--
ALTER TABLE `estado`
  ADD PRIMARY KEY (`id_estado`);

--
-- Indexes for table `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD PRIMARY KEY (`barbearia_id_barbearia`,`barbeiro_id_barbeiro`),
  ADD KEY `fk_barbearia_has_barbeiro_barbearia1_idx` (`barbearia_id_barbearia`),
  ADD KEY `fk_barbearia_has_barbeiro_barbeiro1_idx` (`barbeiro_id_barbeiro`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `avaliacao`
--
ALTER TABLE `avaliacao`
  MODIFY `id_avaliacao` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `barbearia`
--
ALTER TABLE `barbearia`
  MODIFY `id_barbearia` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `barbeiro`
--
ALTER TABLE `barbeiro`
  MODIFY `id_barbeiro` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cidade`
--
ALTER TABLE `cidade`
  MODIFY `id_cidade` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cliente`
--
ALTER TABLE `cliente`
  MODIFY `id_cliente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `corte`
--
ALTER TABLE `corte`
  MODIFY `id_corte` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `estado`
--
ALTER TABLE `estado`
  MODIFY `id_estado` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `agendamento`
--
ALTER TABLE `agendamento`
  ADD CONSTRAINT `fk_cliente_has_barbeiro_barbeiro1` FOREIGN KEY (`barbeiro_id_barbeiro`) REFERENCES `barbeiro` (`id_barbeiro`) ON DELETE NO ACTION,
  ADD CONSTRAINT `fk_cliente_has_barbeiro_cliente1` FOREIGN KEY (`cliente_id_cliente`) REFERENCES `cliente` (`id_cliente`) ON DELETE NO ACTION;

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `avaliacao`
--
ALTER TABLE `avaliacao`
  ADD CONSTRAINT `fk_avaliacao_agendamento1` FOREIGN KEY (`agendamento_cliente_id_cliente`,`agendamento_barbeiro_id_barbeiro`) REFERENCES `agendamento` (`cliente_id_cliente`, `barbeiro_id_barbeiro`) ON DELETE NO ACTION;

--
-- Constraints for table `barbearia`
--
ALTER TABLE `barbearia`
  ADD CONSTRAINT `fk_barbearias_cidades1` FOREIGN KEY (`cidades_id_cidade`) REFERENCES `cidade` (`id_cidade`) ON DELETE NO ACTION;

--
-- Constraints for table `barbeiro`
--
ALTER TABLE `barbeiro`
  ADD CONSTRAINT `FK_barbeiro_AspNetUsers_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION;

--
-- Constraints for table `cidade`
--
ALTER TABLE `cidade`
  ADD CONSTRAINT `fk_cidades_estados1` FOREIGN KEY (`estados_id_estado`) REFERENCES `estado` (`id_estado`) ON DELETE NO ACTION;

--
-- Constraints for table `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `FK_cliente_AspNetUsers_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION,
  ADD CONSTRAINT `fk_cliente_cidades` FOREIGN KEY (`cidades_id_cidade`) REFERENCES `cidade` (`id_cidade`) ON DELETE NO ACTION;

--
-- Constraints for table `corte_por_barbeiro`
--
ALTER TABLE `corte_por_barbeiro`
  ADD CONSTRAINT `fk_corte_has_barbeiro_barbeiro1` FOREIGN KEY (`barbeiro_id_barbeiro`) REFERENCES `barbeiro` (`id_barbeiro`) ON DELETE NO ACTION,
  ADD CONSTRAINT `fk_corte_has_barbeiro_corte1` FOREIGN KEY (`corte_id_corte`) REFERENCES `corte` (`id_corte`) ON DELETE NO ACTION;

--
-- Constraints for table `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD CONSTRAINT `fk_barbearia_has_barbeiro_barbearia1` FOREIGN KEY (`barbearia_id_barbearia`) REFERENCES `barbearia` (`id_barbearia`) ON DELETE NO ACTION,
  ADD CONSTRAINT `fk_barbearia_has_barbeiro_barbeiro1` FOREIGN KEY (`barbeiro_id_barbeiro`) REFERENCES `barbeiro` (`id_barbeiro`) ON DELETE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
