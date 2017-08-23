CREATE PROCEDURE TRIGGER_EXPLOSION.alta_afiliado
	(@username varchar(255),
	@nombre VARCHAR(255),
	 @apellido VARCHAR(255),
	 @descripcion_tipo_documento VARCHAR(255), --viene de TipoDocumento
	 @numero_documento NUMERIC(18,0),
	 @sexo VARCHAR(255), -- masculino o femenino
	 @direccion VARCHAR(255),
	 @telefono NUMERIC(18,0),
	 @mail VARCHAR(255),
	 @fecha_nacimiento DATETIME,
	 @descripcion_estado_civil VARCHAR(255), 
	 @descripcion_plan_medico VARCHAR(255) --viene de PlanMedico
	)
	
AS

-- Primero chequeamos que no esten desabilitados TODOS los afiliados
IF (SELECT TOP 1 Id_rol FROM Rol WHERE ( Nombre = 'Afiliado' AND Habilitado = 1)) IS NOT NULL
BEGIN

	DECLARE @Id_usuario NUMERIC(18,0)
	DECLARE @Id_tipo_documento NUMERIC(18,0)
	DECLARE @Id_estado_civil NUMERIC(18,0)
	DECLARE @Id_plan_medico NUMERIC(18,0)
	DECLARE @Id_afiliado NUMERIC(18,0)

	SELECT TOP 1 @Id_usuario = id_usuario
	FROM TRIGGER_EXPLOSION.Usuario
	WHERE @username = Username
		AND Habilitado = 1
	
	SELECT TOP 1 @Id_tipo_documento = Id_tipo_documento
	FROM TRIGGER_EXPLOSION.TipoDocumento
	WHERE @descripcion_tipo_documento = Descripcion
	
	SELECT TOP 1 @Id_plan_medico = Id_plan
	FROM TRIGGER_EXPLOSION.PlanMedico
	WHERE @descripcion_plan_medico = Descripcion

	SELECT TOP 1 @id_estado_civil = Id_estado_civil
	FROM TRIGGER_EXPLOSION.EstadoCivil
	WHERE @descripcion_estado_civil = Descripcion

	
	SELECT TOP 1 @id_afiliado = Id_afiliado + 1
	FROM TRIGGER_EXPLOSION.Afiliado
	WHERE @numero_documento = Numero_documento
	ORDER BY id_afiliado DESC
	
	IF @Id_afiliado IS NOT NULL
	BEGIN
		SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado ON 
		INSERT INTO TRIGGER_EXPLOSION.Afiliado	(id_afiliado,
 												 id_usuario,
												 nombre,
												 apellido,
												 id_tipo_documento,
												 numero_documento,
												 direccion,
												 telefono,
												 mail,
												 fecha_nacimiento,
												 sexo,
												 id_estado_civil,
												 Plan_id,
												 Habilitado
												)
		VALUES	(@id_afiliado,
				 @id_usuario,
 				 @nombre,
				 @apellido,
				 @id_tipo_documento,
				 @numero_documento,
				 @direccion,
				 @telefono,
				 @mail,
				 @fecha_nacimiento,
				 @sexo,
				 @id_estado_civil,
				 @id_plan_medico,
				 1
				)
		SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado OFF
	END
	ELSE
	BEGIN
		INSERT INTO TRIGGER_EXPLOSION.Afiliado	(id_usuario,
												 nombre,
												 apellido,
												 id_tipo_documento,
												 numero_documento,
												 direccion,
												 telefono,
												 mail,
												 fecha_nacimiento,
												 sexo,
												 id_estado_civil,
												 Plan_id,
												 Habilitado
												)
		VALUES	(@id_usuario,
 				 @nombre,
				 @apellido,
				 @id_tipo_documento,
				 @numero_documento,
				 @direccion,
				 @telefono,
				 @mail,
				 @fecha_nacimiento,
				 @sexo,
				 @id_estado_civil,
				 @id_plan_medico,
				 1
				)
	END
	
END
GO

----------------------------------------------------------------------
-----------------------modificar_afiliado-----------------------------
----------------------------------------------------------------------

CREATE PROCEDURE TRIGGER_EXPLOSION.modificar_afiliado
	(@sexo VARCHAR(255), --masculino o femenino
	 @direccion VARCHAR(255),
	 @telefono NUMERIC(18,0),
	 @mail VARCHAR(255),
	 @descripcion_estado_civil VARCHAR(255), --viene de EstadoCivil
	 @descripcion_plan_medico VARCHAR(255), --viene de PlanMedico
	 @motivo_modificacion VARCHAR(255), -- se podria hacer con un trigger pero como mandamos el motive(?
	 @id_afiliado NUMERIC(18,0)
	)

AS


BEGIN
	DECLARE @Id_estado_civil NUMERIC(18,0)
	DECLARE @Id_plan_medico NUMERIC(18,0)
	DECLARE @Id_plan_viejo NUMERIC(18,0)
	DECLARE @Fecha DATETIME

	SELECT TOP 1 @Id_plan_viejo = Plan_id
	FROM TRIGGER_EXPLOSION.Afiliado
	WHERE @id_afiliado = Id_afiliado

	SELECT TOP 1 @Id_plan_medico = Id_plan
	FROM TRIGGER_EXPLOSION.PlanMedico
	WHERE @descripcion_plan_medico = Descripcion

	SELECT TOP 1 @id_estado_civil = Id_estado_civil
	FROM TRIGGER_EXPLOSION.EstadoCivil
	WHERE @descripcion_estado_civil = Descripcion
			
	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET	direccion = @direccion,
		telefono = @telefono,
		mail = @mail,
		sexo = @sexo,
		id_estado_civil = @id_estado_civil,
		Plan_id = @Id_plan_medico
	WHERE @id_afiliado = id_afiliado
	
	IF(@motivo_modificacion IS NOT NULL)
	BEGIN
		SET @fecha = CURRENT_TIMESTAMP
		INSERT INTO TRIGGER_EXPLOSION.Modificaciones_afiliado(Id_afiliado, Motivo, Fecha_modificacion, Plan_viejo_id)
		VALUES (@id_afiliado, @motivo_modificacion, @fecha, @Id_plan_viejo)
	END
	
END
GO

----------------------------------------------------------------------
--------------------------baja_afiliado-------------------------------
----------------------------------------------------------------------

CREATE PROCEDURE TRIGGER_EXPLOSION.baja_afiliado
	(@id_afiliado NUMERIC(18, 0))

AS

BEGIN

	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET Habilitado = 0
	WHERE id_afiliado = @id_afiliado
	
END
GO



----------------------------------------------------------------------
--------------------------crear_usuario-------------------------------
----------------------------------------------------------------------

CREATE PROCEDURE TRIGGER_EXPLOSION.alta_usuario
	(@username varchar(255),
	 @contrasenia varchar(255))

AS

BEGIN

	INSERT INTO TRIGGER_EXPLOSION.Usuario (Username, Contrasenia, Intentos_fallidos, Primer_login)
	VALUES (@username, @contrasenia, 0, 1)
	
END
GO
