-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: 22-Maio-2018 às 14:46
-- Versão do servidor: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `thebarber`
--
CREATE DATABASE IF NOT EXISTS `thebarber` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `thebarber`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
CREATE TABLE IF NOT EXISTS `agendamento` (
  `cliente_id_cliente` int(11) NOT NULL,
  `barbeiro_id_barbeiro` int(11) NOT NULL,
  `horario` datetime DEFAULT NULL,
  PRIMARY KEY (`cliente_id_cliente`,`barbeiro_id_barbeiro`),
  KEY `fk_cliente_has_barbeiro_barbeiro1_idx` (`barbeiro_id_barbeiro`),
  KEY `fk_cliente_has_barbeiro_cliente1_idx` (`cliente_id_cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `avaliacao`
--

DROP TABLE IF EXISTS `avaliacao`;
CREATE TABLE IF NOT EXISTS `avaliacao` (
  `id_avaliacao` int(11) NOT NULL AUTO_INCREMENT,
  `nota_cliente` int(11) DEFAULT NULL,
  `nota_barbeiro` int(11) DEFAULT NULL,
  `agendamento_cliente_id_cliente` int(11) NOT NULL,
  `agendamento_barbeiro_id_barbeiro` int(11) NOT NULL,
  PRIMARY KEY (`id_avaliacao`,`agendamento_cliente_id_cliente`,`agendamento_barbeiro_id_barbeiro`),
  KEY `fk_avaliacao_agendamento1_idx` (`agendamento_cliente_id_cliente`,`agendamento_barbeiro_id_barbeiro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `barbearia`
--

DROP TABLE IF EXISTS `barbearia`;
CREATE TABLE IF NOT EXISTS `barbearia` (
  `id_barbearia` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `logradouro` varchar(45) DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `cidades_id_cidade` int(11) NOT NULL,
  `Complemento` varchar(45) DEFAULT NULL,
  `Bairro` varchar(45) DEFAULT NULL,
  `cnpj` varchar(14) DEFAULT NULL,
  PRIMARY KEY (`id_barbearia`),
  KEY `fk_barbearias_cidades1_idx` (`cidades_id_cidade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `barbeiro`
--

DROP TABLE IF EXISTS `barbeiro`;
CREATE TABLE IF NOT EXISTS `barbeiro` (
  `id_barbeiro` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `logradouro` varchar(45) DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `Complemento` varchar(45) DEFAULT NULL,
  `Bairro` varchar(45) DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `barbeirocol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_barbeiro`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `barbeiro`
--

INSERT INTO `barbeiro` (`id_barbeiro`, `nome`, `logradouro`, `numero`, `Complemento`, `Bairro`, `cpf`, `barbeirocol`) VALUES
(1, 'matheus', 'Rua prof severino', 123, 'apt 302', 'nova era', '12398909860', NULL),
(2, 'matheus', 'Rua prof severino', 123, 'apt 302', 'nova era', '12398909860', NULL),
(3, 'matheus', 'Rua prof severino', 123, 'apt 302', 'nova era', '12398909860', NULL),
(4, 'matheus', 'Rua prof severino', 123, 'apt 302', 'nova era', '12398909860', NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `cidade`
--

DROP TABLE IF EXISTS `cidade`;
CREATE TABLE IF NOT EXISTS `cidade` (
  `id_cidade` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `estados_id_estado` int(11) NOT NULL,
  PRIMARY KEY (`id_cidade`),
  KEY `fk_cidades_estados1_idx` (`estados_id_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

DROP TABLE IF EXISTS `cliente`;
CREATE TABLE IF NOT EXISTS `cliente` (
  `id_cliente` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `logradouro` varchar(45) DEFAULT NULL,
  `numero` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cep` varchar(45) DEFAULT NULL,
  `cidades_id_cidade` int(11) NOT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`id_cliente`),
  KEY `fk_cliente_cidades_idx` (`cidades_id_cidade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `corte`
--

DROP TABLE IF EXISTS `corte`;
CREATE TABLE IF NOT EXISTS `corte` (
  `id_corte` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `foto` varchar(45) DEFAULT NULL,
  `valor` float DEFAULT NULL,
  `cortecol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_corte`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `corte_por_barbeiro`
--

DROP TABLE IF EXISTS `corte_por_barbeiro`;
CREATE TABLE IF NOT EXISTS `corte_por_barbeiro` (
  `corte_id_corte` int(11) NOT NULL,
  `barbeiro_id_barbeiro` int(11) NOT NULL,
  PRIMARY KEY (`corte_id_corte`,`barbeiro_id_barbeiro`),
  KEY `fk_corte_has_barbeiro_barbeiro1_idx` (`barbeiro_id_barbeiro`),
  KEY `fk_corte_has_barbeiro_corte1_idx` (`corte_id_corte`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `estado`
--

DROP TABLE IF EXISTS `estado`;
CREATE TABLE IF NOT EXISTS `estado` (
  `id_estado` int(11) NOT NULL AUTO_INCREMENT,
  `uf` varchar(2) DEFAULT NULL,
  `nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionarios`
--

DROP TABLE IF EXISTS `funcionarios`;
CREATE TABLE IF NOT EXISTS `funcionarios` (
  `barbearia_id_barbearia` int(11) NOT NULL,
  `barbeiro_id_barbeiro` int(11) NOT NULL,
  PRIMARY KEY (`barbearia_id_barbearia`,`barbeiro_id_barbeiro`),
  KEY `fk_barbearia_has_barbeiro_barbeiro1_idx` (`barbeiro_id_barbeiro`),
  KEY `fk_barbearia_has_barbeiro_barbearia1_idx` (`barbearia_id_barbearia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `agendamento`
--
ALTER TABLE `agendamento`
  ADD CONSTRAINT `fk_cliente_has_barbeiro_barbeiro1` FOREIGN KEY (`barbeiro_id_barbeiro`) REFERENCES `barbeiro` (`id_barbeiro`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_cliente_has_barbeiro_cliente1` FOREIGN KEY (`cliente_id_cliente`) REFERENCES `cliente` (`id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `avaliacao`
--
ALTER TABLE `avaliacao`
  ADD CONSTRAINT `fk_avaliacao_agendamento1` FOREIGN KEY (`agendamento_cliente_id_cliente`,`agendamento_barbeiro_id_barbeiro`) REFERENCES `agendamento` (`cliente_id_cliente`, `barbeiro_id_barbeiro`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `barbearia`
--
ALTER TABLE `barbearia`
  ADD CONSTRAINT `fk_barbearias_cidades1` FOREIGN KEY (`cidades_id_cidade`) REFERENCES `cidade` (`id_cidade`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `cidade`
--
ALTER TABLE `cidade`
  ADD CONSTRAINT `fk_cidades_estados1` FOREIGN KEY (`estados_id_estado`) REFERENCES `estado` (`id_estado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `fk_cliente_cidades` FOREIGN KEY (`cidades_id_cidade`) REFERENCES `cidade` (`id_cidade`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `corte_por_barbeiro`
--
ALTER TABLE `corte_por_barbeiro`
  ADD CONSTRAINT `fk_corte_has_barbeiro_barbeiro1` FOREIGN KEY (`barbeiro_id_barbeiro`) REFERENCES `barbeiro` (`id_barbeiro`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_corte_has_barbeiro_corte1` FOREIGN KEY (`corte_id_corte`) REFERENCES `corte` (`id_corte`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD CONSTRAINT `fk_barbearia_has_barbeiro_barbearia1` FOREIGN KEY (`barbearia_id_barbearia`) REFERENCES `barbearia` (`id_barbearia`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_barbearia_has_barbeiro_barbeiro1` FOREIGN KEY (`barbeiro_id_barbeiro`) REFERENCES `barbeiro` (`id_barbeiro`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
