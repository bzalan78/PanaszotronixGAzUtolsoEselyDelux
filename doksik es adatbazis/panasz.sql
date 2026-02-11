-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jan 29. 12:31
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `panaszotronix`
--
CREATE DATABASE IF NOT EXISTS `panaszotronix` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `panaszotronix`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `panaszkonyv`
--

CREATE TABLE `panaszkonyv` (
  `id` int(11) NOT NULL,
  `tanar_neve` varchar(100) NOT NULL,
  `diak_neve` varchar(100) NOT NULL,
  `email` varchar(150) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `datum` date NOT NULL,
  `panasz` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `panaszkonyv`
--

INSERT INTO `panaszkonyv` (`id`, `tanar_neve`, `diak_neve`, `email`, `telefon`, `datum`, `panasz`) VALUES
(1, 'Kovács Péter', 'Nagy Anna', 'anna1@email.hu', '06301111111', '2024-01-10', 'A tanár gyakran késik.'),
(2, 'Szabó Éva', 'Kiss Balázs', 'balazs2@email.hu', '06302222222', '2024-01-11', 'Túl sok házi feladatot ad.'),
(3, 'Tóth László', 'Horváth Dóra', 'dora3@email.hu', '06303333333', '2024-01-12', 'Nem érthető a magyarázat.'),
(4, 'Németh Zoltán', 'Varga Péter', 'peter4@email.hu', '06304444444', '2024-01-13', 'Igazságtalan jegyek.'),
(5, 'Farkas Júlia', 'Molnár Eszter', 'eszter5@email.hu', '06305555555', '2024-01-14', 'Nem válaszol e-mailre.'),
(6, 'Kovács Péter', 'Szabó Bence', 'bence6@email.hu', '06306666666', '2024-01-15', 'Hangosan beszél az órán.'),
(7, 'Szabó Éva', 'Tóth Lili', 'lili7@email.hu', '06307777777', '2024-01-16', 'Nem enged kérdezni.'),
(8, 'Tóth László', 'Kiss Ádám', 'adam8@email.hu', '06308888888', '2024-01-17', 'Nem követi a tanmenetet.'),
(9, 'Németh Zoltán', 'Nagy Réka', 'reka9@email.hu', '06309999999', '2024-01-18', 'Későn javít dolgozatot.'),
(10, 'Farkas Júlia', 'Horváth Máté', 'mate10@email.hu', '06301010101', '2024-01-19', 'Kevés gyakorlás.'),
(11, 'Kovács Péter', 'Diák 11', 'diak11@email.hu', '06301111112', '2024-01-20', 'Elfogult viselkedés.'),
(12, 'Szabó Éva', 'Diák 12', 'diak12@email.hu', '06302222223', '2024-01-21', 'Nem tartja az óra végét.'),
(13, 'Tóth László', 'Diák 13', 'diak13@email.hu', '06303333334', '2024-01-22', 'Nem segít felzárkózni.'),
(14, 'Németh Zoltán', 'Diák 14', 'diak14@email.hu', '06304444445', '2024-01-23', 'Zavaros számonkérés.'),
(15, 'Farkas Júlia', 'Diák 15', 'diak15@email.hu', '06305555556', '2024-01-24', 'Nem megfelelő hangnem.');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `panaszkonyv`
--
ALTER TABLE `panaszkonyv`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `panaszkonyv`
--
ALTER TABLE `panaszkonyv`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
