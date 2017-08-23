
------------------------RESETEAR INTENTOS FALLIDOS------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_ResetIntentos(@Id_usuario numeric(18,0))
AS
BEGIN
UPDATE TRIGGER_EXPLOSION.Usuario SET Intentos_fallidos = 0 WHERE Id_usuario = @Id_usuario
END
GO


------------------------CAMBIAR PASSWORD------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_CambiarPassword(@Id_usuario numeric(18,0), @Pass varchar(255))
AS
BEGIN
UPDATE TRIGGER_EXPLOSION.Usuario SET Contrasenia = @Pass where Id_usuario = @Id_usuario
END
GO



------------------------HABILITAR USUARIO------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_HabilitarUsuario(@Id_usuario numeric(18,0)) AS
BEGIN
	UPDATE TRIGGER_EXPLOSION.Usuario SET Habilitado = 1 WHERE Id_usuario = @Id_usuario
END
GO


------------------------AUMENTAR CANTIDAD DE INTENTOS FALLIDOS ------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_SumarIntentoFallido(@Id_usuario numeric(18,0)) AS
BEGIN
	UPDATE TRIGGER_EXPLOSION.Usuario SET Intentos_fallidos = (Intentos_fallidos +1) WHERE Id_usuario = @Id_usuario
END
GO

