-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Tempo de geração: 11-Jun-2020 às 22:21
-- Versão do servidor: 5.6.41-84.1
-- versão do PHP: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `teletu76_XP`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `Album`
--

CREATE TABLE `Album` (
  `ID` int(10) DEFAULT NULL,
  `Nome` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `ApagarMusicas`
--

CREATE TABLE `ApagarMusicas` (
  `ID` int(10) NOT NULL DEFAULT '0',
  `Lugar` varchar(160) DEFAULT NULL,
  `Banda` varchar(152) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Banda`
--

CREATE TABLE `Banda` (
  `ID` double DEFAULT NULL,
  `Nome` varchar(255) DEFAULT NULL,
  `Lugar` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Config`
--

CREATE TABLE `Config` (
  `ArrumaTag` bit(1) NOT NULL,
  `Log` int(10) DEFAULT NULL,
  `Versao` double(24,2) DEFAULT NULL,
  `SaidaNormal` bit(1) NOT NULL,
  `OpcaoArrastoDefault` bit(1) NOT NULL,
  `TempCarrEdit` int(10) DEFAULT NULL,
  `TrocaUser` bit(1) NOT NULL,
  `ListaCErros` int(10) DEFAULT NULL,
  `MaxLR` double(24,2) DEFAULT NULL,
  `im_mus_PorUs` int(10) DEFAULT NULL,
  `nRepetirG` int(10) DEFAULT NULL,
  `TrayIcon` bit(1) NOT NULL,
  `Cut` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `LisMus`
--

CREATE TABLE `LisMus` (
  `ID` int(11) NOT NULL,
  `Lista` int(10) DEFAULT NULL,
  `Musica` int(10) DEFAULT NULL,
  `JaTocou` bit(1) NOT NULL,
  `PosLista` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Musica`
--

CREATE TABLE `Musica` (
  `ID` double DEFAULT NULL,
  `Nome` varchar(255) DEFAULT NULL,
  `Lugar` varchar(255) DEFAULT NULL,
  `Banda` double DEFAULT NULL,
  `Tamanho` double DEFAULT NULL,
  `BitRate` double DEFAULT NULL,
  `Tempo` timestamp(6) NULL DEFAULT NULL,
  `VezErro` double DEFAULT NULL,
  `MaxVol` double DEFAULT NULL,
  `Equalizacao` double DEFAULT NULL,
  `Album` double DEFAULT NULL,
  `TocadoEmG` timestamp(6) NULL DEFAULT NULL,
  `Unid` int(10) DEFAULT NULL,
  `Pular` smallint(5) DEFAULT NULL,
  `Pulado` smallint(5) DEFAULT NULL,
  `NaoAchou` int(10) DEFAULT NULL,
  `CutIni` smallint(5) DEFAULT NULL,
  `CutFim` smallint(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `MusicasComErro`
--

CREATE TABLE `MusicasComErro` (
  `ID` int(10) DEFAULT NULL,
  `Musica` int(10) DEFAULT NULL,
  `JaTocou` bit(1) NOT NULL,
  `PosLista` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Prefets`
--

CREATE TABLE `Prefets` (
  `ID` int(10) DEFAULT NULL,
  `Nome` varchar(30) DEFAULT NULL,
  `eq0` int(10) DEFAULT NULL,
  `eq1` int(10) DEFAULT NULL,
  `eq2` int(10) DEFAULT NULL,
  `eq3` int(10) DEFAULT NULL,
  `eq4` int(10) DEFAULT NULL,
  `eq5` int(10) DEFAULT NULL,
  `eq6` int(10) DEFAULT NULL,
  `eq7` int(10) DEFAULT NULL,
  `eq8` int(10) DEFAULT NULL,
  `eq9` int(10) DEFAULT NULL,
  `idPerfil` smallint(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Renomear`
--

CREATE TABLE `Renomear` (
  `ID` int(10) DEFAULT NULL,
  `Nome` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Unidades`
--

CREATE TABLE `Unidades` (
  `ID` int(11) NOT NULL,
  `Nome` varchar(34) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Users`
--

CREATE TABLE `Users` (
  `ID` int(10) DEFAULT NULL,
  `Nome` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `ApagarMusicas`
--
ALTER TABLE `ApagarMusicas`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID` (`ID`);

--
-- Índices para tabela `Banda`
--
ALTER TABLE `Banda`
  ADD KEY `Nome` (`Nome`);

--
-- Índices para tabela `LisMus`
--
ALTER TABLE `LisMus`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID` (`ID`),
  ADD KEY `Lista` (`Lista`),
  ADD KEY `ListaMusica` (`Lista`,`Musica`);

--
-- Índices para tabela `Prefets`
--
ALTER TABLE `Prefets`
  ADD KEY `idPerfil` (`idPerfil`);

--
-- Índices para tabela `Unidades`
--
ALTER TABLE `Unidades`
  ADD UNIQUE KEY `ID` (`ID`);

--
-- Índices para tabela `Users`
--
ALTER TABLE `Users`
  ADD UNIQUE KEY `Index_F5C7BA9D_395D_40F7` (`ID`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `LisMus`
--
ALTER TABLE `LisMus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `Unidades`
--
ALTER TABLE `Unidades`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
