use ayd1db;
select * from Usuario;



INSERT INTO Rol_Usuario(nombre, descripcion) values ("Administrador","Usuario administrador tiene accesos diferentes a la aplicación ");
INSERT INTO Rol_Usuario(nombre, descripcion) values ("Cliente","Usuario cliente del sistema bancario, acceso limitado a ciertas funcionalidades");

# TIPOS DE CUENTA
INSERT INTO Tipo_Cuenta (nombre, descripcion) VALUES ("Monetaria", "Cuenta monetaria");
INSERT INTO Tipo_Cuenta (nombre, descripcion) VALUES ("Ahorro", "Cuenta monetaria");
select * from Tipo_Cuenta;

select * from Rol_Usuario;

ALTER TABLE Usuario
	DROP COLUMN nickname;

ALTER TABLE Usuario
	ADD COLUMN nickname VARCHAR(12) NOT NULL AFTER nombre;  


ALTER TABLE Usuario
	ADD COLUMN contraseña VARCHAR(8) NOT NULL AFTER correo;  

ALTER TABLE Cuenta 
	DROP COLUMN saldo;

ALTER TABLE Cuenta
	ADD COLUMN saldo float NOT NULL AFTER idCuenta;      
    

ALTER TABLE Cuenta 
	DROP COLUMN fecha_creacion;

ALTER TABLE Cuenta
	ADD COLUMN fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP  
	ON UPDATE CURRENT_TIMESTAMP AFTER saldo;      
    


select * from Cuenta;


DELIMITER //
CREATE PROCEDURE ADD_USER(IN user_name VARCHAR(50),  IN user_nick VARCHAR(12), IN user_email VARCHAR(50) , IN user_pass VARCHAR(8))
BEGIN	
DECLARE cod_user INT;

INSERT INTO Usuario (nombre, nickname, correo, contraseña, idrolUsuario) values (user_name, user_nick, user_email,user_pass, 2);

SET cod_user = (select idUsuario from Usuario where idUsuario = LAST_INSERT_ID());
IF cod_user IS NOT NULL THEN
	INSERT INTO Cuenta (saldo, idtipoCuenta, idUsuario) VALUES (0.0, 1,cod_user);
END IF;

END
//
DELIMITER ;





