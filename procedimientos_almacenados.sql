use ayd1db;
select * from Usuario;



INSERT INTO Rol_Usuario(nombre, descripcion) values ("Administrador","Usuario administrador tiene accesos diferentes a la aplicación ");
INSERT INTO Rol_Usuario(nombre, descripcion) values ("Cliente","Usuario cliente del sistema bancario, acceso limitado a ciertas funcionalidades");

select * from Rol_Usuario;

ALTER TABLE Usuario
	DROP COLUMN nickname;

ALTER TABLE Usuario
	ADD COLUMN nickname VARCHAR(12) NOT NULL AFTER nombre;  


ALTER TABLE Usuario
	ADD COLUMN contraseña VARCHAR(8) NOT NULL AFTER correo;  


DELIMITER //
CREATE PROCEDURE ADD_USER(IN user_name VARCHAR(50), IN user_nick VARCHAR(50),  IN user_email VARCHAR(150) , IN user_pass VARCHAR(8))
BEGIN	

INSERT INTO Usuario (nombre, nickname, correo, contraseña, idrolUsuario) values (user_name, user_nick, user_email,user_pass, 2);
   
END
//
