-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema bd_gestao_concurso
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bd_gestao_concurso
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bd_gestao_concurso` DEFAULT CHARACTER SET utf8mb3 ;
USE `bd_gestao_concurso` ;

-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`candidato`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`candidato` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `NumeroInscricao` INT NULL DEFAULT NULL,
  `Nome` VARCHAR(45) NULL DEFAULT NULL,
  `Cpf` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`estado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`estado` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NULL DEFAULT NULL,
  `regiao` VARCHAR(45) NULL DEFAULT NULL,
  `uf` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`cidade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`cidade` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `municipio` VARCHAR(45) NULL DEFAULT NULL,
  `EstadoId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Cidade_Estado1_idx` (`EstadoId` ASC) VISIBLE,
  CONSTRAINT `fk_Cidade_Estado1`
    FOREIGN KEY (`EstadoId`)
    REFERENCES `bd_gestao_concurso`.`estado` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`concurso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`concurso` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Edital` VARCHAR(200) NULL DEFAULT NULL,
  `DataConcurso` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`disciplina`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`disciplina` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Disciplina` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`concursodisciplina`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`concursodisciplina` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `DataRegistro` DATETIME NULL DEFAULT NULL,
  `DisciplinaId` INT NOT NULL,
  `ConcursoId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_disciplina_has_concurso_concurso1_idx` (`ConcursoId` ASC) VISIBLE,
  INDEX `fk_disciplina_has_concurso_disciplina_idx` (`DisciplinaId` ASC) VISIBLE,
  CONSTRAINT `fk_disciplina_has_concurso_concurso1`
    FOREIGN KEY (`ConcursoId`)
    REFERENCES `bd_gestao_concurso`.`concurso` (`Id`),
  CONSTRAINT `fk_disciplina_has_concurso_disciplina`
    FOREIGN KEY (`DisciplinaId`)
    REFERENCES `bd_gestao_concurso`.`disciplina` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`endereco` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Rua` VARCHAR(45) NULL DEFAULT NULL,
  `Numero` VARCHAR(45) NULL DEFAULT NULL,
  `Bairro` VARCHAR(45) NULL DEFAULT NULL,
  `Complemento` VARCHAR(45) NULL DEFAULT NULL,
  `Ativo` INT NULL DEFAULT NULL,
  `CandidatoId` INT NOT NULL,
  `CidadeId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_endereco_candidato1_idx` (`CandidatoId` ASC) VISIBLE,
  INDEX `fk_Endereco_Cidade1_idx` (`CidadeId` ASC) VISIBLE,
  CONSTRAINT `fk_endereco_candidato1`
    FOREIGN KEY (`CandidatoId`)
    REFERENCES `bd_gestao_concurso`.`candidato` (`Id`),
  CONSTRAINT `fk_Endereco_Cidade1`
    FOREIGN KEY (`CidadeId`)
    REFERENCES `bd_gestao_concurso`.`cidade` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`inscricao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`inscricao` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `DataInscricao` DATETIME NULL DEFAULT NULL,
  `CandidatoId` INT NOT NULL,
  `ConcursoId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Pontuacao_candidato1_idx` (`CandidatoId` ASC) VISIBLE,
  INDEX `fk_Inscricao_Concurso1_idx` (`ConcursoId` ASC) VISIBLE,
  CONSTRAINT `fk_Inscricao_Concurso1`
    FOREIGN KEY (`ConcursoId`)
    REFERENCES `bd_gestao_concurso`.`concurso` (`Id`),
  CONSTRAINT `fk_Pontuacao_candidato1`
    FOREIGN KEY (`CandidatoId`)
    REFERENCES `bd_gestao_concurso`.`candidato` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `bd_gestao_concurso`.`pontuacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_gestao_concurso`.`pontuacao` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nota` DECIMAL(10,0) NULL DEFAULT NULL,
  `ConcursoDisciplinaId` INT NOT NULL,
  `InscricaoId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Pontuacao_ConcursoDisciplina2_idx` (`ConcursoDisciplinaId` ASC) VISIBLE,
  INDEX `fk_Pontuacao_Inscricao1_idx` (`InscricaoId` ASC) VISIBLE,
  CONSTRAINT `fk_Pontuacao_ConcursoDisciplina2`
    FOREIGN KEY (`ConcursoDisciplinaId`)
    REFERENCES `bd_gestao_concurso`.`concursodisciplina` (`Id`),
  CONSTRAINT `fk_Pontuacao_Inscricao1`
    FOREIGN KEY (`InscricaoId`)
    REFERENCES `bd_gestao_concurso`.`inscricao` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
