-- Toma un Rol, devuelve una tabla con los datos de ese rol
CREATE FUNCTION TRIGGER_EXPLOSION.SP_getRol(@id_rol numeric(18,0))
	RETURNS @rol TABLE(
						 id_rol numeric(18,0),
						 descripcion varchar(255))
AS
BEGIN

	INSERT INTO @rol
	SELECT r.Nombre from TRIGGER_EXPLOSION.Rol r
	WHERE Id_rol=@id_rol AND r.Habilitado=1

	RETURN
END
GO

-- es el modificarRol
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_updateRol
(@id_rol numeric(18,0), @nombre varchar(255)) 
AS
BEGIN	
	UPDATE TRIGGER_EXPLOSION.Rol
	SET nombre = @nombre
	WHERE id_rol = @id_rol
END
GO


-- chequea si se encuentra habilitado el rol, devuelve boolean
CREATE FUNCTION TRIGGER_EXPLOSION.SP_validarRol(@id_rol numeric(18,0)) 
RETURNS BIT
AS
BEGIN	
	DECLARE @validado BIT

	SELECT TOP 1  @validado = Habilitado
	FROM TRIGGER_EXPLOSION.Rol
	WHERE id_rol = @id_rol

	RETURN @validado
END
GO

-- crea un rol
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_altaRol
(@nombre varchar(255)) 
AS
BEGIN	

	IF((SELECT nombre FROM TRIGGER_EXPLOSION.Rol WHERE nombre = @nombre) IS NULL )
	INSERT INTO TRIGGER_EXPLOSION.Rol (Nombre) 
	VALUES (@nombre)
END
GO

--borra un rol de la DB
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_bajaRol
(@id_rol numeric(18,0)) 
AS
BEGIN	
	DELETE TRIGGER_EXPLOSION.Rol
	WHERE Id_rol = @id_rol
END
GO

-- deshabilita un Rol
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_deshabilitarRol
(@id_rol numeric(18,0)) 
AS
BEGIN	
	UPDATE TRIGGER_EXPLOSION.Rol
	SET Habilitado = 0
	WHERE Id_rol = @id_rol
END
GO

-- habilita un Rol
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_habilitarRol
(@id_rol numeric(18,0)) 
AS
BEGIN	
	UPDATE TRIGGER_EXPLOSION.Rol
	SET Habilitado = 1
	WHERE Id_rol = @id_rol
END
GO

CREATE FUNCTION TRIGGER_EXPLOSION.getRolesDelUsuario(@username varchar(255)) 
	RETURNS @Roles TABLE (
							id numeric(18,0),
							valor	varchar(255)
	)
AS
BEGIN	

	INSERT INTO @Roles (id, valor)
	SELECT R.Id_rol, R.Nombre
	FROM TRIGGER_EXPLOSION.Usuario U 
	JOIN TRIGGER_EXPLOSION.UsuarioXRol UxR on (U.Id_usuario = UxR.Id_usuario)
	JOIN TRIGGER_EXPLOSION.Rol R ON (R.Id_rol = UxR.Id_rol) 
	WHERE U.Username = @username
	
	
	RETURN
END
GO



CREATE FUNCTION TRIGGER_EXPLOSION.getFuncDelRol(@rol varchar(255)) 
	RETURNS @Func TABLE (
							id numeric(18,0),
							valor	varchar(255)
	)
AS
BEGIN	
	
	INSERT INTO @Func
	SELECT f.Id_funcionalidad, f.Nombre
	FROM TRIGGER_EXPLOSION.Rol r
	JOIN TRIGGER_EXPLOSION.RolXFuncionalidad rxf on (r.Id_rol = rxf.Id_rol)
	JOIN TRIGGER_EXPLOSION.Funcionalidad f on (rxf.Id_funcionalidad = f.Id_funcionalidad)
	WHERE r.Nombre = @rol
		
	RETURN
END
GO


