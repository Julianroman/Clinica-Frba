CREATE SCHEMA [TRIGGER_EXPLOSION] AUTHORIZATION [gd];
	GO
	

BEGIN TRY
	
	BEGIN TRANSACTION TRANSACCION_INICIAL

	--ACA VA TODA LA QUERY PROPIAMENTE DICHA *****************************************

	
	--COMIENZA CREACION DE TABLAS------------------------------------
	CREATE TABLE TRIGGER_EXPLOSION.Usuario
	(
	Id_usuario				numeric(18,0) IDENTITY(1,1),
	Habilitado				bit DEFAULT 1,
	Username				varchar(255),
	Contrasenia				varchar(255),
	Primer_login			bit DEFAULT 1,
	Intentos_fallidos		numeric(18,0) DEFAULT 0,

	CONSTRAINT PK_Usuario PRIMARY KEY (Id_usuario),
	)

	CREATE TABLE TRIGGER_EXPLOSION.PlanMedico
	(
	Id_plan						numeric(18,0) IDENTITY(1,1),
	Precio_bono_consulta		numeric(18,0),
	Costo						numeric(18,0),
	Descripcion					varchar(255),
	Precio_bono_farmacia		numeric(18,0),
	PRIMARY KEY(Id_plan)
	)


	CREATE TABLE TRIGGER_EXPLOSION.Rol
	(
	Id_rol					numeric(18,0) IDENTITY(1,1),
	Nombre					varchar(255), --Vamos a usarlo para diferenciar el tipo de rol
	Habilitado				bit DEFAULT 1,
	PRIMARY KEY (Id_rol)

	)


	CREATE TABLE TRIGGER_EXPLOSION.Funcionalidad
	(
	Id_funcionalidad			numeric(18,0) IDENTITY(1,1),
	Nombre						varchar(255),
	PRIMARY KEY(Id_funcionalidad)
	)

	CREATE TABLE TRIGGER_EXPLOSION.RolXFuncionalidad
	(
	Id_funcionalidad			numeric(18,0),
	Id_rol						numeric(18,0),
	CONSTRAINT PK_RolXFuncionalidad PRIMARY KEY (Id_funcionalidad,Id_rol)
	)

	CREATE TABLE TRIGGER_EXPLOSION.UsuarioXRol
	(
	Id_usuario					numeric(18,0),
	Id_rol						numeric(18,0),
	CONSTRAINT PK_UsuarioXRol PRIMARY KEY (Id_usuario,Id_rol),
	CONSTRAINT FK_UsuarioXRol_Usuario FOREIGN KEY (Id_usuario) REFERENCES TRIGGER_EXPLOSION.Usuario(Id_usuario),
	CONSTRAINT FK_UsuarioXRol_Rol FOREIGN KEY (Id_rol) REFERENCES TRIGGER_EXPLOSION.Rol(Id_rol)
	) 


	CREATE TABLE TRIGGER_EXPLOSION.EstadoCivil
	(
	Id_estado_civil				numeric(18,0) IDENTITY(1,1),
	Descripcion					varchar(255),
	CONSTRAINT PK_EstadoCivil PRIMARY KEY (Id_estado_civil)
	)


	CREATE TABLE TRIGGER_EXPLOSION.TipoDocumento
	(
	Id_tipo_documento			numeric(18,0) IDENTITY(1,1),
	Descripcion					varchar(255)

	CONSTRAINT PK_TipoDocumento PRIMARY KEY (Id_tipo_documento)
	)

	CREATE TABLE TRIGGER_EXPLOSION.Afiliado
	(
	Id_afiliado					numeric(18,0) IDENTITY(001,100),
	Id_usuario					numeric(18,0),
	Rol_id						numeric(18,0),
	Plan_id						numeric(18,0),
	Total_consultas_medicas		numeric(18,0) DEFAULT 0,
	Familiares_a_cargo			smallint DEFAULT 0,
	Conyuge						numeric(18,0),
	Id_estado_civil				numeric(18,0) DEFAULT 1,
	Nombre						varchar(255),
	Apellido					varchar(255),
	Numero_documento			numeric(18,0),
	Direccion					varchar(255),
	Telefono					numeric(18,0),
	Mail						varchar(255),
	Fecha_nacimiento			datetime,
	Id_tipo_documento			numeric(18,0)  DEFAULT 1, --el tipo de documento default es DNI, 
	Sexo						varchar(255),
	Habilitado					BIT,
	id_afiliado_padre			NUMERIC(18,0)

	--CONSTRAINT chk_Sexo_Afiliado	CHECK (Sexo = 'masculino' OR Sexo='femenino'),
	CONSTRAINT PK_AFILIADOS PRIMARY KEY (Id_afiliado),
	CONSTRAINT FK_Afiliado_Plan FOREIGN KEY(Plan_id) REFERENCES TRIGGER_EXPLOSION.PlanMedico(Id_plan),
	CONSTRAINT FK_Afiliado_Usuario FOREIGN KEY(Id_usuario) REFERENCES TRIGGER_EXPLOSION.Usuario(Id_usuario),
	CONSTRAINT FK_Afiliado_Conyuge FOREIGN KEY(Conyuge) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado),
	CONSTRAINT FK_Afiliado_Tipo_documento FOREIGN KEY (Id_tipo_documento) REFERENCES TRIGGER_EXPLOSION.TipoDocumento,
	CONSTRAINT FK_Afiliado_EstadoCivil FOREIGN KEY(Id_estado_civil) REFERENCES TRIGGER_EXPLOSION.EstadoCivil(Id_estado_civil),
	CONSTRAINT FK_Afiliado_Padre FOREIGN KEY(id_afiliado_padre) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado)
	)

	CREATE TABLE TRIGGER_EXPLOSION.Modificaciones_afiliado
	(
	Id_modificacion				numeric(18,0) IDENTITY(1,1),
	Id_afiliado					numeric(18,0),
	Plan_viejo_id				numeric(18,0),
	Motivo						varchar(255),
	Fecha_modificacion			DateTime,

	CONSTRAINT PK_MODIFICACION PRIMARY KEY (Id_modificacion),
	CONSTRAINT FK_Afiliado FOREIGN KEY(Id_afiliado) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado),
	CONSTRAINT FK_PlanViejo FOREIGN KEY(Plan_viejo_id) REFERENCES TRIGGER_EXPLOSION.PlanMedico(Id_plan)
	)

	CREATE TABLE TRIGGER_EXPLOSION.Profesional
	(
	Id_profesional				numeric(18,0) IDENTITY(1,1),
	Id_usuario					numeric(18,0),
	Matricula					numeric(18,0),
	Rol_id						numeric(18,0),
	Nombre						varchar(255),
	Apellido					varchar(255),
	Numero_documento			numeric(18,0),
	Tipo_documento				numeric(18,0),
	Direccion					varchar(255),
	Telefono					numeric(18,0),
	Mail						varchar(255),
	Fecha_Nacimiento			datetime,
	Id_tipo_documento			numeric(18,0) DEFAULT 1, --el tipo de documento default es DNI
	Sexo						varchar(255),
	Habilitado					BIT,

	CONSTRAINT chk_Sexo_Profesional	CHECK (Sexo IN ('masculino','femenino')),
	CONSTRAINT FK_Profesional_Rol FOREIGN KEY(Rol_id) REFERENCES TRIGGER_EXPLOSION.Rol(Id_rol),
	CONSTRAINT FK_Profesional_Tipo_documento FOREIGN KEY (Id_tipo_documento) REFERENCES TRIGGER_EXPLOSION.TipoDocumento,
	CONSTRAINT FK_Profesional_Usuario FOREIGN KEY(Id_usuario) REFERENCES TRIGGER_EXPLOSION.Usuario(Id_usuario),
	CONSTRAINT PK_Profesional PRIMARY KEY (Id_profesional)
	)


	CREATE TABLE TRIGGER_EXPLOSION.TipoEspecialidad
	(
	Codigo_tipo_especialidad		numeric(18,0) IDENTITY(1,1),
	Descripcion					varchar(255),

	CONSTRAINT PK_TipoEspecialidad PRIMARY KEY (Codigo_tipo_especialidad)
	

	)


	CREATE TABLE TRIGGER_EXPLOSION.Especialidad(
	Id_especialidad				numeric(18,0) IDENTITY(1,1),
	Descripcion					varchar(255),
	Codigo_tipo_especialidad		numeric(18,0),

	CONSTRAINT PK_Especialidad PRIMARY KEY (Id_especialidad),
	CONSTRAINT FK_Especialidad_TipoEspecialidad FOREIGN KEY(Codigo_tipo_especialidad) REFERENCES TRIGGER_EXPLOSION.TipoEspecialidad(Codigo_tipo_especialidad)
	)

	CREATE TABLE TRIGGER_EXPLOSION.ProfesionalXEspecialidad
	(
	Id_especialidad				numeric(18,0),
	Id_profesional				numeric(18,0),

	CONSTRAINT PK_ProfesionalXEspecialidad PRIMARY KEY (Id_especialidad, Id_profesional)
	)


	CREATE TABLE TRIGGER_EXPLOSION.Turno
	(
	Id_turno				numeric(18,0) IDENTITY(1,1),
	Id_afiliado				numeric(18,0),
	Id_profesional			numeric(18,0),
	Fecha_programada		datetime,
	Fecha_y_hora_llegada	datetime,
	Especialidad_id			numeric(18,0),
	Cancelado BIT DEFAULT 0,


	CONSTRAINT FK_Turno_Especialidad FOREIGN KEY (Especialidad_id) REFERENCES TRIGGER_EXPLOSION.Especialidad (Id_especialidad),
	CONSTRAINT PK_Turno PRIMARY KEY (Id_turno),
	CONSTRAINT FK_Turno_Afiliado FOREIGN KEY(Id_afiliado) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado),
	CONSTRAINT FK_Turno_Profesional FOREIGN KEY(Id_profesional) REFERENCES TRIGGER_EXPLOSION.Profesional(Id_profesional),
	

	)


	CREATE TABLE TRIGGER_EXPLOSION.ConsultaMedica
	(
	Id_consulta				numeric(18,0) IDENTITY(1,1),
	Sintomas				varchar(255),
	Diagnostico				varchar(255),
	Consulta_realizada		bit DEFAULT 0,
	Fecha_y_hora			datetime,


	CONSTRAINT PK_ConsultaMedica PRIMARY KEY (Id_consulta),
	CONSTRAINT FK_ConsultaMedica_Turno FOREIGN KEY(Id_consulta) REFERENCES TRIGGER_EXPLOSION.Turno(Id_turno)
	)

	
	CREATE TABLE TRIGGER_EXPLOSION.Compra
	(
	Id_compra				numeric(18,0) IDENTITY(1,1),
	Cantidad_bonos			numeric(18,0),
	Costo_total				numeric(18,0),
	Id_afiliado				numeric(18,0),
	Fecha					datetime,

	CONSTRAINT PK_Compra PRIMARY KEY (Id_compra),
	CONSTRAINT FK_Compra_Afiliado FOREIGN KEY(Id_afiliado) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado)


	)

	CREATE TABLE TRIGGER_EXPLOSION.Bono
	(
	Id_bono					numeric(18,0) IDENTITY(1,1),
	Id_compra				numeric(18,0),
	Id_afiliado_comprador	numeric(18,0),
	Id_plan_original		numeric(18,0),
	Numero_consulta_medica	numeric(18,0),
	Id_usado_por			numeric(18,0),
	Fecha_impresion			datetime,
	Descripcion				varchar(255),

	CONSTRAINT PK_Bono PRIMARY KEY (Id_bono, Id_afiliado_comprador), --Dice que cada ID de bono es particular de cada afiliado, revisar
	CONSTRAINT FK_Bono_Compra FOREIGN KEY(Id_compra) REFERENCES TRIGGER_EXPLOSION.Compra(Id_Compra),
	CONSTRAINT FK_Bono_AfiliadoComprador FOREIGN KEY(Id_afiliado_comprador) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado),
	CONSTRAINT FK_Bono_PlanOriginal FOREIGN KEY(Id_plan_original) REFERENCES TRIGGER_EXPLOSION.PlanMedico(Id_plan),
	CONSTRAINT FK_Bono_AfiliadoUsadoPor FOREIGN KEY(Id_usado_por) REFERENCES TRIGGER_EXPLOSION.Afiliado(Id_afiliado),
	)


	CREATE TABLE TRIGGER_EXPLOSION.TipoCancelacion
	(
	Id_tipo_cancelacion				numeric(18,0) IDENTITY(1,1),
	Descripcion						varchar(255),

	CONSTRAINT PK_TipoCancelacion PRIMARY KEY (Id_tipo_cancelacion)
	)

	CREATE TABLE TRIGGER_EXPLOSION.Cancelacion
	(
	Id_cancelacion			numeric(18,0) IDENTITY(1,1),
	Id_tipo_cancelacion		numeric(18,0),
	Motivo					varchar(255),
	Id_turno				numeric(18,0),

	CONSTRAINT PK_Cancelacion PRIMARY KEY (Id_cancelacion),
	CONSTRAINT FK_Cancelacion_TipoCancelacion FOREIGN KEY(Id_tipo_cancelacion) REFERENCES TRIGGER_EXPLOSION.TipoCancelacion(Id_tipo_cancelacion),
	CONSTRAINT FK_Cancelacion_Turno FOREIGN KEY(Id_turno) REFERENCES TRIGGER_EXPLOSION.Turno(Id_turno)

	)

	CREATE TABLE TRIGGER_EXPLOSION.Agenda
	(
	Id_agenda				numeric(18,0) IDENTITY(1,1),
	Id_profesional			numeric(18,0),
	Fecha_inicio			DATETIME,
	Fecha_fin				DATETIME,
	Especialidad			varchar(255)


	CONSTRAINT PK_Agenda PRIMARY KEY (Id_agenda),
	CONSTRAINT FK_Agenda_Profesional FOREIGN KEY(Id_profesional) REFERENCES TRIGGER_EXPLOSION.Profesional(Id_profesional)

	)

		CREATE TABLE TRIGGER_EXPLOSION.Dias_disponible
	(
	Id_dia					numeric(18,0) IDENTITY(1,1),
	Id_agenda				numeric(18,0),
	Dia						varchar(255),
	inicio_jornada			TIME,
	fin_jornada				TIME,


	CONSTRAINT PK_Dias_Disponible PRIMARY KEY (Id_dia),
	CONSTRAINT FK_Dias_Agenda FOREIGN KEY(Id_agenda) REFERENCES TRIGGER_EXPLOSION.Agenda(Id_agenda)

	)


	-----------------------------TERMINA CREACION DE TABLAS--------------------------------------------------


	-------------------------------COMIENZA MIGRACION DE DATOS-------------------------------------


	--*****************************ROL*******************************************
	INSERT INTO TRIGGER_EXPLOSION.Rol
	(Nombre) values ('Afiliado'), ('Profesional'), ('Administrador')


	--*****************************Estado Civil*******************************************
	INSERT INTO TRIGGER_EXPLOSION.EstadoCivil(Descripcion)
	values ('Soltero'), ('Casado'), ('Divorciado'), ('Viudo')

	--*****************************Usuario***********************************************
	INSERT INTO TRIGGER_EXPLOSION.Usuario(Username, Contrasenia)
	SELECT DISTINCT Medico_Dni, 'w23e'
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL
	UNION
	SELECT DISTINCT Paciente_Dni, 'w23e'
	FROM gd_esquema.Maestra

	--*****************************Tipo de documento*******************************************
	INSERT INTO TRIGGER_EXPLOSION.TipoDocumento(Descripcion)
	VALUES ('DNI'), ('CI'), ('LC')

	
	--*****************************Planes*******************************************
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.PlanMedico ON
	INSERT INTO TRIGGER_EXPLOSION.PlanMedico(Id_plan, Precio_bono_consulta,Precio_bono_farmacia, Descripcion)
	SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia ,Plan_Med_Descripcion
	FROM gd_esquema.Maestra
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.PlanMedico OFF


	--*****************************TipoEspecialidad*******************************************
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.TipoEspecialidad ON
	INSERT INTO TRIGGER_EXPLOSION.TipoEspecialidad (Codigo_tipo_especialidad, Descripcion)
	SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
		FROM gd_esquema.Maestra
		WHERE Tipo_Especialidad_Codigo IS NOT NULL;
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.TipoEspecialidad OFF

	--*****************************Especialidad*******************************************
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Especialidad ON
	INSERT INTO TRIGGER_EXPLOSION.Especialidad (Id_especialidad, Descripcion, Codigo_tipo_especialidad)
	SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
		FROM gd_esquema.Maestra
		WHERE Tipo_Especialidad_Codigo IS NOT NULL;
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Especialidad OFF

		--***************************Profesional**************************************************
	INSERT INTO TRIGGER_EXPLOSION.Profesional(Id_usuario,Nombre,Apellido,Direccion,Mail,Fecha_Nacimiento,Telefono,Numero_documento, Habilitado, Rol_id, Tipo_documento)
	SELECT DISTINCT U.Id_usuario, UPPER(LEFT(M.Medico_Nombre,1))+LOWER(SUBSTRING(M.Medico_Nombre,2,LEN(M.Medico_Nombre))), M.Medico_Apellido, M.Medico_Direccion, M.Medico_Mail, M.Medico_Fecha_Nac, M.Medico_Telefono, M.Medico_Dni, 1, 2, 1
	FROM TRIGGER_EXPLOSION.Usuario U, gd_esquema.Maestra M
	WHERE U.Username  = CAST(M.Medico_Dni AS varchar(255))


	--*****************************ProfesionalXEspecialidad*******************************************
	INSERT INTO TRIGGER_EXPLOSION.ProfesionalXEspecialidad (Id_especialidad, Id_profesional)
	SELECT DISTINCT e.Id_especialidad, p.Id_profesional
		FROM TRIGGER_EXPLOSION.Profesional p, TRIGGER_EXPLOSION.Especialidad e, gd_esquema.Maestra m
		WHERE p.Numero_documento=m.Medico_Dni AND e.Id_especialidad=m.Especialidad_Codigo;

	--*****************************Funcionalidad*******************************************
	INSERT INTO TRIGGER_EXPLOSION.Funcionalidad (Nombre)
	VALUES ('Cargar Agenda'), ('Sacar Turno'), ('Comprar Bonos'), ('ABM Rol'), ('ABM Afiliado'), ('Estadisticas'), ('Cancelar Turno'),  ('Registrar Diagnostico'), ('Registrar Llegada Paciente')

	--*****************************RolXFunc*******************************************
	INSERT INTO TRIGGER_EXPLOSION.RolXFuncionalidad(Id_rol, Id_funcionalidad)
	VALUES (1,2), (1,3), (2,1), (3,3), (3,4), (3,5), (3,6), (1,7), (2,7), (2,8),(3,9)

	--***************************Afiliado**************************************************
	INSERT INTO TRIGGER_EXPLOSION.Afiliado(Id_usuario, Nombre, Apellido, Numero_documento, Direccion,Mail,Plan_id,Fecha_nacimiento, Id_tipo_documento, Habilitado, Telefono, Total_consultas_medicas, Rol_id)
	SELECT DISTINCT U.Id_usuario, M.Paciente_Nombre, M.Paciente_Apellido, M.Paciente_Dni, M.Paciente_Direccion, M.Paciente_Mail, M.Plan_Med_Codigo,M.Paciente_Fecha_Nac, 1, 1, m.Paciente_Telefono, MAX(m.Bono_Consulta_Numero) total_consultas, 1
	FROM gd_esquema.Maestra M, TRIGGER_EXPLOSION.Usuario U
	WHERE U.Username = CAST(M.Paciente_Dni AS varchar(255))
	GROUP BY U.Id_usuario, M.Paciente_Nombre, M.Paciente_Apellido, M.Paciente_Dni, M.Paciente_Direccion, M.Paciente_Mail, M.Plan_Med_Codigo,M.Paciente_Fecha_Nac, M.Paciente_Telefono


	--*****************************UsuarioXRol*******************************************

	INSERT INTO TRIGGER_EXPLOSION.UsuarioXRol (Id_usuario, Id_rol)
	SELECT A.Id_usuario, r.Id_rol
	FROM TRIGGER_EXPLOSION.Afiliado A, TRIGGER_EXPLOSION.Rol R
	WHERE R.Nombre = 'Afiliado'

	INSERT INTO TRIGGER_EXPLOSION.UsuarioXRol (Id_usuario, Id_rol)
	SELECT P.Id_usuario, r.Id_rol
	FROM TRIGGER_EXPLOSION.Profesional P, TRIGGER_EXPLOSION.Rol R
	WHERE R.Nombre = 'Profesional'

	INSERT INTO TRIGGER_EXPLOSION.UsuarioXRol (Id_usuario, Id_rol)
	SELECT U.Id_usuario, r.Id_rol
	FROM TRIGGER_EXPLOSION.Rol R, TRIGGER_EXPLOSION.Usuario U
	WHERE R.Nombre = 'Administrador' AND U.Username = 'admin'
	



	--*****************************Turno*******************************************
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Turno ON
	INSERT INTO TRIGGER_EXPLOSION.Turno (Id_turno, Id_afiliado, Id_profesional, Fecha_programada, Especialidad_id)
	SELECT DISTINCT m.Turno_Numero, a.Id_afiliado, p.Id_profesional, m.Turno_Fecha, m.Especialidad_Codigo
	FROM gd_esquema.Maestra m
	JOIN TRIGGER_EXPLOSION.Afiliado a ON (m.Paciente_Dni = a.Numero_documento)
	JOIN TRIGGER_EXPLOSION.Profesional p ON (m.Medico_Dni = p.Numero_documento)
	WHERE Turno_Numero IS NOT NULL AND m.Bono_Consulta_Numero IS NULL
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Turno OFF

	--*****************************ConsultaMedica*******************************************

	SET IDENTITY_INSERT TRIGGER_EXPLOSION.ConsultaMedica ON
	INSERT INTO TRIGGER_EXPLOSION.ConsultaMedica (Id_consulta, Sintomas, Diagnostico, Consulta_realizada, Fecha_y_hora)
	SELECT DISTINCT t.Id_turno, m.Consulta_Sintomas, m.Consulta_Enfermedades, 1, m.Turno_Fecha
		FROM gd_esquema.Maestra m JOIN TRIGGER_EXPLOSION.Turno t ON (t.Id_turno = m.Turno_Numero)
		WHERE m.Bono_Consulta_Numero IS NOT NULL
		ORDER BY t.Id_turno
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.ConsultaMedica OFF

	--*****************************Compras*******************************************

	INSERT INTO TRIGGER_EXPLOSION.Compra (Id_afiliado, Fecha, Cantidad_bonos, Costo_total)
	SELECT DISTINCT Id_afiliado, Bono_Consulta_Fecha_Impresion, COUNT( Bono_Consulta_Numero) Cantidad_bonos, Plan_Med_Precio_Bono_Consulta
	FROM gd_esquema.Maestra m
	JOIN TRIGGER_EXPLOSION.Afiliado a ON (a.Numero_documento = m.Paciente_Dni)
	WHERE Bono_Consulta_Fecha_Impresion IS NOT NULL
	group by Id_afiliado, Bono_Consulta_Fecha_Impresion, Plan_Med_Precio_Bono_Consulta
	ORDER BY Id_afiliado


	--*****************************Bono*******************************************

	INSERT INTO TRIGGER_EXPLOSION.Bono (Numero_consulta_medica, Id_compra, Id_afiliado_comprador, Id_usado_por,Id_plan_original, Fecha_impresion)
	SELECT DISTINCT m.Bono_Consulta_Numero, c.Id_compra, a.id_afiliado, a.Id_afiliado, a.Plan_id, m.Bono_Consulta_Fecha_Impresion
	FROM TRIGGER_EXPLOSION.Afiliado a 
	JOIN gd_esquema.Maestra m ON (a.Numero_documento = m.Paciente_Dni AND m.Bono_Consulta_Numero iS NOT NULL)
	JOIN TRIGGER_EXPLOSION.Compra c ON (m.Compra_Bono_Fecha = c.Fecha AND A.Id_afiliado = c.Id_afiliado)
	WHERE m.Bono_Consulta_Numero IS NOT NULL
	ORDER BY Bono_Consulta_Numero


	--*****************************Agenda*******************************************

	INSERT INTO TRIGGER_EXPLOSION.Agenda (Id_profesional, Especialidad, Fecha_inicio, Fecha_fin)
	SELECT p.Id_profesional, e.Descripcion,  MIN(Turno_Fecha), MAX(Turno_Fecha)
	FROM gd_esquema.Maestra m
	JOIN TRIGGER_EXPLOSION.Profesional p ON (p.Numero_documento = Medico_Dni)
	JOIN TRIGGER_EXPLOSION.Especialidad e ON (e.Id_especialidad = m.Especialidad_Codigo)
	WHERE Turno_fecha is not null
	GROUP BY p.Id_profesional, e.Descripcion

	--*****************************DiasDisponible*******************************************

	SELECT Medico_Dni, Especialidad_Descripcion,DATENAME(WEEKDAY, Turno_fecha) Dia,cast(Turno_fecha as time) [Horas]
	INTO #TempAgenda
	FROM gd_esquema.Maestra m
	WHERE Turno_fecha is not null;


	INSERT INTO TRIGGER_EXPLOSION.Dias_disponible (Id_agenda,Dia, inicio_jornada, fin_jornada) 
	SELECT DISTINCT a.Id_agenda,t.Dia, MIN(t.Horas), MAX(t.Horas)
	FROM #TempAgenda t
	JOIN TRIGGER_EXPLOSION.Profesional p ON (p.Numero_documento = Medico_Dni)
	JOIN TRIGGER_EXPLOSION.Agenda a ON (a.Id_profesional = p.Id_profesional)
	GROUP BY a.Id_agenda, t.Dia
	ORDER BY Id_agenda

	Drop Table #TempAgenda 

	--*****************************TipoCancelacion*******************************************

	INSERT INTO TRIGGER_EXPLOSION.TipoCancelacion (Descripcion)
	VALUES ('Problemas de horario'), ('Trabajo'), ('Prefiero no informar')

		------------------------------admin---------------------------------------------

	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Usuario ON
	INSERT INTO TRIGGER_EXPLOSION.Usuario (Id_usuario, Username, Contrasenia, Primer_login)
	VALUES (0, 'admin','w23e', 1) -- El admin sera el usuario 0 
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Usuario OFF

	INSERT INTO TRIGGER_EXPLOSION.UsuarioXRol (Id_usuario, Id_rol)
	VALUES (0, 1), (0,2), (0,3)

	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado ON
	INSERT INTO TRIGGER_EXPLOSION.Afiliado (Id_afiliado, id_usuario, Plan_id, Total_consultas_medicas, Id_estado_civil, nombre, apellido, Id_tipo_documento, sexo, Habilitado, Rol_id,Numero_documento)
	VALUES (0, 0, 555555, 0, 1,'admin', 'admin', 1, 'masculino', 1, 1,0) -- El admin sera el usuario 0 
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado OFF


	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Profesional ON
	INSERT INTO TRIGGER_EXPLOSION.Profesional (Id_profesional, id_usuario, Matricula, Rol_id, nombre, apellido, Id_tipo_documento, sexo, Habilitado)
	VALUES (0, 0, 555555, 2,'admin', 'admin', 1, 'masculino', 1) -- El admin sera el usuario 0 
	SET IDENTITY_INSERT TRIGGER_EXPLOSION.Profesional OFF

	-- el admin tiene la especialidad 9999 Alergeologia
	INSERT INTO TRIGGER_EXPLOSION.ProfesionalXEspecialidad (Id_especialidad,Id_profesional)
	VALUES(9999,0)
	


		----------------------------------TERMINA MIGRACION DE DATOS----------------------------------------------------

	COMMIT TRANSACTION TRANSACCION_INICIAL
END TRY

BEGIN CATCH
	IF(@@TRANCOUNT > 0 )
	BEGIN
	ROLLBACK TRANSACTION TRANSACCION_INICIAL
	PRINT 'ERROR DETECTADO, TODOS LOS CAMBIOS REVERTIDOS'
	END
	    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage





END CATCH
GO
	--***************************Stored Procedures**************************************************

-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
---------------------------------------USUARIOS------------------------------------------------
------------------------------------------------------------------------------------------------


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

------------------------DESHABILITAR USUARIO------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_DesHabilitarUsuario(@Id_usuario numeric(18,0)) AS
BEGIN
	UPDATE TRIGGER_EXPLOSION.Usuario SET Habilitado = 0 WHERE Id_usuario = @Id_usuario
END
GO


------------------------AUMENTAR CANTIDAD DE INTENTOS FALLIDOS ------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_SumarIntentoFallido(@Id_usuario numeric(18,0)) AS
BEGIN
	UPDATE TRIGGER_EXPLOSION.Usuario SET Intentos_fallidos = (Intentos_fallidos +1) WHERE Id_usuario = @Id_usuario
END
GO


------------------------CAMBIO EL FLAG DE PRIMERA VEZ ------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.SP_PrimeraVez(@Value numeric(18,0), @ID numeric(18,0)) 
AS
BEGIN
UPDATE  TRIGGER_EXPLOSION.Usuario SET Primer_login = @Value WHERE Id_usuario = @ID
END
GO


-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
--------------------------------------AGENDA MEDICA--------------------------------------------
-----------------------------------------------------------------------------------------------


--------------------Devuelve el ID de profesional dado el ID de usuario------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.GetIdProfesional(@Value numeric(18,0),  @Return numeric(18,0) output) 

AS
BEGIN
	DECLARE @profesional  numeric(18,0)
	SELECT  @profesional = Id_Profesional
	FROM TRIGGER_EXPLOSION.Profesional  
	WHERE Id_usuario =  @Value
	SET @Return = @profesional
END
GO


--devuelve el horario de inicio y fin para el dia  especialidad y profesional dados
CREATE FUNCTION TRIGGER_EXPLOSION.getHorarioDisponibleDelDia(@Especialidad varchar(50), @Dia varchar(255), @Profesional numeric(18,0), @IdAgenda numeric(18,0))
RETURNS  @func TABLE (hora_inicio time(7), hora_fin time(7))
AS
BEGIN
INSERT INTO @func
select inicio_jornada, fin_jornada
FROM TRIGGER_EXPLOSION.Dias_disponible dd JOIN TRIGGER_EXPLOSION.Agenda a ON dd.Id_agenda = a.Id_agenda
 and a.Especialidad = @Especialidad 
 and dd.Dia = @Dia 
 and a.Id_profesional = @Profesional
 and dd.Id_agenda = @IdAgenda
RETURN
END
GO



----------- ---------Muestra la disponibilidad con el id-usuario que recibe---------------------

CREATE PROCEDURE TRIGGER_EXPLOSION.InsertDisponibilidadPorIdUsuario(@id_profesional numeric(18,0), @fecha_init DATE, @fecha_fin DATE, @especialidad numeric(18,0), @Return numeric(18,0) output)
AS
BEGIN
	-- IF EXISTS(SELECT * FROM service s WHERE s.service_id = ?)
	INSERT INTO TRIGGER_EXPLOSION.Agenda (Id_profesional, Fecha_inicio,Fecha_fin, Especialidad)
	VALUES (@id_profesional, @fecha_init, @fecha_fin, @especialidad);

	DECLARE @i numeric(18,0) = 0
	WHILE  @i= DATEDIFF(DAY, @fecha_init,@fecha_fin)

	SET @Return= 0

END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.InsertarDiasPorDisponibilidad(@id_agenda numeric(18,0),@fecha DATE, @hora_init TIME, @hora_fin TIME, @Return numeric(18,0) output)
AS
BEGIN

	INSERT INTO TRIGGER_EXPLOSION.Dias_disponible(Id_agenda, Dia,inicio_jornada, fin_jornada)
	VALUES (@id_agenda,DATENAME(DAY, @fecha), @hora_init, @hora_fin);
	
	

END
GO

	


-------Devuelve el id afiliado dado el dni

CREATE PROCEDURE TRIGGER_EXPLOSION.GetIdAfiliado(@Value numeric(18,0),  @Return numeric(18,0) output) 

AS
BEGIN
	
	SELECT @Return = Id_afiliado
	FROM TRIGGER_EXPLOSION.Afiliado 
	WHERE Numero_documento =  @Value
	--SET @Return = Id_afiliado
END
GO



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
	 @descripcion_plan_medico VARCHAR(255), --viene de PlanMedico
	 @cantidad_familiares SMALLINT,
	 @id_afiliado_padre NUMERIC(18,0)
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

	IF(@id_afiliado_padre != 0)
	BEGIN
		-- Entonces es un familiar drop procedure trigger_explosion.alta_afiliado
		SET @id_afiliado = (SELECT max(Id_afiliado) FROM TRIGGER_EXPLOSION.Afiliado WHERE Id_afiliado BETWEEN @id_afiliado_padre AND @id_afiliado_padre + 99) +1


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
												 Habilitado,
												 Familiares_a_cargo,
												 id_afiliado_padre,
												 Rol_id

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
				 1,
				 @cantidad_familiares,
				 @id_afiliado_padre,
				 1
				 
				)
		SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado OFF
	
	END
	ELSE 
	BEGIN

		SET @id_afiliado = (SELECT TOP 1 id_afiliado FROM TRIGGER_EXPLOSION.Afiliado where Id_afiliado LIKE '%01' order by Id_afiliado DESC)							+ 100
		SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado ON
		INSERT INTO TRIGGER_EXPLOSION.Afiliado	(
												 Id_afiliado,
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
												 Habilitado,
												 Familiares_a_cargo,
												 Rol_id
												 
												)
		VALUES	( 
				 @Id_afiliado,
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
				 1,
				 @cantidad_familiares,
				 1
				 
				)
		SET IDENTITY_INSERT TRIGGER_EXPLOSION.Afiliado OFF
	
	END
	

	INSERT INTO TRIGGER_EXPLOSION.UsuarioXRol (Id_usuario, Id_rol)
	VALUES (@Id_usuario, 1)


END
GO

CREATE FUNCTION TRIGGER_EXPLOSION.YaExisteAfiliadoConDocumento (@numero_documento NUMERIC(18,0), @descr_tipo_documento varchar(50))
RETURNS BIT
AS
BEGIN
	DECLARE @result smallint;

	SELECT @result = COUNT(*)
	FROM TRIGGER_EXPLOSION.Afiliado 
	WHERE Numero_documento = @numero_documento 
	AND Id_tipo_documento = (SELECT Id_tipo_documento FROM TRIGGER_EXPLOSION.TipoDocumento WHERE Descripcion = @descr_tipo_documento)

	IF(@result = 0)
	RETURN 0 -- 0 = false, no existe ningun afiliado con ese documento

	RETURN 1;
END
GO

----------------------------------------------------------------------
-----------------------modificar_afiliado-----------------------------
----------------------------------------------------------------------

CREATE PROCEDURE TRIGGER_EXPLOSION.modificar_afiliado
	(@sexo VARCHAR(255) = NULL, --masculino o femenino
	 @direccion VARCHAR(255) = NULL,
	 @telefono NUMERIC(18,0) = NULL,
	 @mail VARCHAR(255) = NULL,
	 @descripcion_estado_civil VARCHAR(255) = NULL, --viene de EstadoCivil
	 @descripcion_plan_medico VARCHAR(255) = NULL, --viene de PlanMedico
	 @motivo_modificacion VARCHAR(255) = NULL, -- se podria hacer con un trigger pero como mandamos el motive(?
	 @id_afiliado NUMERIC(18,0),
	 @fecha_modif DATETIME
	)

AS
BEGIN
	DECLARE @Id_estado_civil NUMERIC(18,0)
	DECLARE @Id_plan_medico NUMERIC(18,0)
	DECLARE @Id_plan_viejo NUMERIC(18,0)

	SELECT TOP 1 @Id_plan_viejo = Plan_id
	FROM TRIGGER_EXPLOSION.Afiliado
	WHERE @id_afiliado = Id_afiliado

	SELECT TOP 1 @Id_plan_medico = Id_plan
	FROM TRIGGER_EXPLOSION.PlanMedico
	WHERE @descripcion_plan_medico = Descripcion

	SELECT TOP 1 @id_estado_civil = Id_estado_civil
	FROM TRIGGER_EXPLOSION.EstadoCivil
	WHERE @descripcion_estado_civil = Descripcion
			
	IF(@sexo IS NOT NULL)
	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET	sexo = @sexo
	WHERE @id_afiliado = id_afiliado

	IF(@direccion IS NOT NULL)
	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET direccion = @direccion
	WHERE @id_afiliado = Id_afiliado

	IF(@telefono IS NOT NULL)
	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET telefono = @telefono
	WHERE @id_afiliado = Id_afiliado

	IF(@mail IS NOT NULL)
	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET mail = @mail
	WHERE @id_afiliado = Id_afiliado

	IF(@id_estado_civil IS NOT NULL)
	UPDATE TRIGGER_EXPLOSION.Afiliado
	SET id_estado_civil = @id_estado_civil
	WHERE @id_afiliado = Id_afiliado

	IF(@Id_plan_medico IS NOT NULL)
	BEGIN
		UPDATE TRIGGER_EXPLOSION.Afiliado
		SET direccion = @direccion,
			telefono = @telefono,
			mail = @mail,
			sexo = @sexo,
			id_estado_civil = @id_estado_civil,
			Plan_id = @Id_plan_medico
		WHERE @id_afiliado = Id_afiliado

		INSERT INTO TRIGGER_EXPLOSION.Modificaciones_afiliado(Id_afiliado, Motivo, Fecha_modificacion, Plan_viejo_id)
		VALUES (@id_afiliado, @motivo_modificacion, @fecha_modif, @Id_plan_viejo)
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
(@nombre varchar(30)) 
AS
BEGIN	
	UPDATE TRIGGER_EXPLOSION.Rol
	SET Habilitado = 1
	WHERE Nombre = @nombre
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.RolHabilitado(@nombre varchar(30))
AS
BEGIN
	DECLARE @resultado bit
	SET @resultado = (SELECT Habilitado FROM TRIGGER_EXPLOSION.Rol WHERE Nombre = @nombre)
	RETURN @resultado
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.ExisteRol(@nombre varchar(255))
AS
BEGIN
	DECLARE @existe int
	Set @existe = (SELECT COUNT(Id_rol) FROM TRIGGER_EXPLOSION.ROL WHERE nombre = @nombre)
	return @existe
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.obtenerRolId(@nombre varchar(255))
AS
BEGIN 
DECLARE @id numeric(18,0)
SET @id = (SELECT Id_rol FROM TRIGGER_EXPLOSION.Rol WHERE nombre = @nombre)
RETURN @id
END 
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.ModificarNombreRol(@nombre varchar(255), @anterior varchar(255))
AS
BEGIN
UPDATE TRIGGER_EXPLOSION.Rol SET Nombre = @nombre
WHERE Nombre = @anterior
END
GO


CREATE PROCEDURE TRIGGER_EXPLOSION.getRoles
AS
BEGIN
	SELECT Nombre FROM TRIGGER_EXPLOSION.Rol
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.getRolesHabilitados
AS
BEGIN 
	SELECT Nombre FROM TRIGGER_EXPLOSION.Rol WHERE Habilitado = 1
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

CREATE PROCEDURE TRIGGER_EXPLOSION.inhabilitarRolXUsuario(@id numeric(18,0))
AS
BEGIN
	DELETE FROM TRIGGER_EXPLOSION.UsuarioXRol
	WHERE Id_usuario = @id
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

CREATE PROCEDURE TRIGGER_EXPLOSION.FuncionalidadesPorRol(@Rol varchar(255))
AS
BEGIN
SELECT f.Nombre FROM TRIGGER_EXPLOSION.RolXFuncionalidad rxf 
JOIN TRIGGER_EXPLOSION.Rol r ON r.Id_rol = rxf.Id_rol
JOIN TRIGGER_EXPLOSION.Funcionalidad f ON f.Id_funcionalidad = rxf.Id_funcionalidad
WHERE r.Nombre = @ROL
END
GO


CREATE PROCEDURE TRIGGER_EXPLOSION.getFuncionalidades
AS
BEGIN
	SELECT Nombre FROM TRIGGER_EXPLOSION.Funcionalidad
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.obtenerFuncionalidadId(@nombre varchar(255))
AS 
BEGIN
DECLARE @id numeric(18,0)
SET @id = (SELECT Id_funcionalidad FROM TRIGGER_EXPLOSION.Funcionalidad WHERE Nombre = @nombre)
RETURN @id
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.asignarFuncionalidad(@idRol numeric(18,0), @idFunc numeric(18,0))
AS
BEGIN
INSERT INTO TRIGGER_EXPLOSION.RolXFuncionalidad(Id_funcionalidad, Id_rol) values (@idFunc, @idRol)
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.EliminarFuncionalidades(@rol numeric(18,0))
AS
BEGIN
	DELETE FROM TRIGGER_EXPLOSION.RolXFuncionalidad WHERE Id_rol = @rol
END
GO

----------------------------------------------------------------------
-----------------------turnos_dia_siguiente---------------------------
----------------------------------------------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.turnos_dia_siguiente
	(@username varchar(255),
	 @fecha_actual DATETIME)

AS 

BEGIN

	SELECT t.Id_turno Turno, p.Nombre + ' ' + p.Apellido Medico, e.Descripcion Especialidad, t.Fecha_programada Fecha
	FROM TRIGGER_EXPLOSION.Turno t
	JOIN TRIGGER_EXPLOSION.Profesional P ON (t.Id_profesional = p.Id_profesional)
	JOIN TRIGGER_EXPLOSION.Especialidad E ON (e.Id_especialidad = T.Especialidad_id)
	JOIN TRIGGER_EXPLOSION.Afiliado A ON (a.Id_afiliado = t.Id_afiliado)
	JOIN TRIGGER_EXPLOSION.Usuario U on (u.Id_usuario = a.Id_usuario)
	WHERE u.Username = @username AND (DATEDIFF(day,@fecha_actual,t.Fecha_programada) >= 1) AND t.Cancelado = 0
	-- cuando la diferencia es a futuro, datediff devuelve valores negativos
END
GO

-- Para probar con username Afiliado 17599330. Username Doc:80527583
--insert into TRIGGER_EXPLOSION.Turno (Fecha_programada, Id_afiliado, id_profesional, especialidad_id)
--values (CONVERT(DATE,'2016-11-05'), 1201, 15, 10010)

-- select * from TRIGGER_EXPLOSION.Turno WHERE Id_afiliado = 1201

----------------------------------------------------------------------
-----------------------cancelar_turno---------------------------
----------------------------------------------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.cancelar_turno
	(@id_turno NUMERIC(18,0),
	 @motivo_cancelacion varchar(255),
	 @id_tipo_cancelacion NUMERIC(18,0))

AS

BEGIN


		UPDATE TRIGGER_EXPLOSION.Turno
		SET Cancelado = 1
		WHERE Id_turno = @id_turno

		-- Ver como se van a manejar las consultas, si se crea al mismo tiempo que se asigna un turno entonces aca tenemos que borrarla

		INSERT INTO TRIGGER_EXPLOSION.Cancelacion (Id_tipo_cancelacion, Motivo, Id_turno)
		VALUES (@id_tipo_cancelacion, @motivo_cancelacion, @id_turno)

	
END
GO

-- drop procedure TRIGGER_EXPLOSION.cancelar_turno_fechaEspecifica
CREATE PROCEDURE TRIGGER_EXPLOSION.cancelar_turno_fechaEspecifica
	(@fecha DATETIME,
	 @motivo_cancelacion varchar(255),
	 @id_tipo_cancelacion NUMERIC(18,0))

AS

BEGIN

		CREATE TABLE #TurnosActualizados (id_turno NUMERIC(18,0))

		UPDATE TRIGGER_EXPLOSION.Turno
		SET Cancelado = 1
		OUTPUT INSERTED.Id_turno INTO #TurnosActualizados
		WHERE CONVERT(DATE,Fecha_programada) = CONVERT(DATE,@fecha)

		-- Ver como se van a manejar las consultas, si se crea al mismo tiempo que se asigna un turno entonces aca tenemos que borrarla


		INSERT INTO TRIGGER_EXPLOSION.Cancelacion (Id_turno, Id_tipo_cancelacion, Motivo)
		SELECT TA.id_turno, @id_tipo_cancelacion, @motivo_cancelacion
		FROM #TurnosActualizados TA

		drop table #TurnosActualizados
		

	
END
GO

CREATE PROCEDURE TRIGGER_EXPLOSION.cancelar_turno_rangoDeFechas
	(@fechaInicio DATETIME,
	 @fechaFin DATETIME,
	 @motivo_cancelacion varchar(255),
	 @id_tipo_cancelacion NUMERIC(18,0))

AS

BEGIN

		CREATE TABLE #TurnosActualizados (id_turno NUMERIC(18,0))

		UPDATE TRIGGER_EXPLOSION.Turno
		SET Cancelado = 1
		OUTPUT INSERTED.Id_turno INTO #TurnosActualizados
		WHERE (CONVERT(DATE,Fecha_programada) BETWEEN CONVERT(DATE,@fechaInicio) AND CONVERT(DATE,@fechaFin))

		-- Ver como se van a manejar las consultas, si se crea al mismo tiempo que se asigna un turno entonces aca tenemos que borrarla


		INSERT INTO TRIGGER_EXPLOSION.Cancelacion (Id_turno, Id_tipo_cancelacion, Motivo)
		SELECT TA.id_turno, @id_tipo_cancelacion, @motivo_cancelacion
		FROM #TurnosActualizados TA

		drop table #TurnosActualizados
		

	
END
GO


CREATE PROCEDURE TRIGGER_EXPLOSION.comprarBonos
	(@id_afiliado NUMERIC(18, 0),
	 @cantidad NUMERIC(5,0),
	 @precioTotal NUMERIC(18,4),
	 @Fecha DATETIME)

AS

BEGIN
	CREATE TABLE #id_compra (id_compra NUMERIC(18,0));
	DECLARE @Id_compra NUMERIC(18,0);
	DECLARE @Id_plan NUMERIC(18,0);

	IF (SELECT TOP 1 Habilitado FROM TRIGGER_EXPLOSION.Afiliado WHERE (Id_afiliado = @id_afiliado)) != 0
	BEGIN
		INSERT INTO TRIGGER_EXPLOSION.Compra (Cantidad_bonos, Costo_total, Fecha, Id_afiliado)
		OUTPUT INSERTED.Id_compra INTO #id_compra
		VALUES (@cantidad, @precioTotal, @Fecha, @id_afiliado)

		SELECT TOP 1 @Id_compra = id_compra
		FROM #id_compra 

		DROP TABLE #id_compra

		SELECT TOP 1 @Id_plan = a.Plan_id 
		FROM TRIGGER_EXPLOSION.Afiliado A
		WHERE a.Id_afiliado = @id_afiliado

		WHILE(@cantidad > 0)
		BEGIN
			INSERT INTO TRIGGER_EXPLOSION.Bono (Id_afiliado_comprador, Id_compra, Id_plan_original, Fecha_impresion)
			VALUES (@id_afiliado, @Id_compra, @Id_plan, @Fecha) 
			SET @cantidad = @cantidad - 1
		END
	END
	
END
GO
---------------------- Especialidades Bonos ---------------
GO
CREATE FUNCTION TRIGGER_EXPLOSION.EspecialidadesBonos(@Semestre int, @Mes int, @Anio int)
RETURNS @Func TABLE (Especialidad varchar(255), Cantidad numeric(18,0))
AS

BEGIN

if @Mes = 0
	begin
	-- filtro por semestre
	DECLARE @MaxMes int
	DECLARE @MinMes int
	if @Semestre = 1
	begin 
	SET @MaxMes = 7
	SET @MinMes = 0
	end
	else
	begin 
	SET @MaxMes = 13
	SET @MinMes = 6
	end

	INSERT INTO @Func
	SELECT TOP 5 e.Descripcion, COUNT(cm.Id_consulta)
	FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.ConsultaMedica cm on
		t.Id_turno = cm.Id_consulta
		JOIN TRIGGER_EXPLOSION.Especialidad e on e.Id_especialidad = t.Especialidad_id
		AND YEAR(t.Fecha_programada) = @Anio
		AND MONTH(t.Fecha_programada) > @MinMes 
		AND MONTH(t.Fecha_programada) < @MaxMes	
	group by e.Descripcion
	order by COUNT(cm.Id_consulta) DESC

	end	
	else
	begin 
	-- filtro por mes
	INSERT INTO @Func
	SELECT TOP 5 e.Descripcion, COUNT(cm.Id_consulta)
	FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.ConsultaMedica cm on
		t.Id_turno = cm.Id_consulta
		JOIN TRIGGER_EXPLOSION.Especialidad e on e.Id_especialidad = t.Especialidad_id
		AND YEAR(t.Fecha_programada) = @Anio
		AND MONTH(t.Fecha_programada) = @Mes		
	group by e.Descripcion
	order by COUNT(cm.Id_consulta) DESC
	end



RETURN
END
GO


------------------ AFILIADOS BONOS ---------------
GO
CREATE FUNCTION TRIGGER_EXPLOSION.AfiliadosBonos (@Semestre int, @Mes int, @Anio int)
RETURNS @Func TABLE(Afiliado varchar(255), CantidadBonos numeric(18,0))
AS

BEGIN
DECLARE @MaxMes int
DECLARE @MinMes int

if @Mes = 0
begin
--filtro por semestre

if @Semestre = 1
	begin 
	SET @MaxMes = 7
	SET @MinMes = 0
	end
	else
	begin 
	SET @MaxMes = 13
	SET @MinMes = 6
	end


INSERT INTO @Func
SELECT TOP 5 a.Nombre+' '+a.Apellido, SUM(c.Cantidad_bonos)
FROM TRIGGER_EXPLOSION.Compra c 
JOIN TRIGGER_EXPLOSION.Afiliado a ON a.Id_afiliado = c.Id_afiliado
	AND YEAR(c.Fecha) = @Anio
	AND MONTH(c.Fecha) > @MinMes
	AND MONTH(c.Fecha) < @MaxMes
	
group by a.Nombre+' '+a.Apellido
ORDER BY SUM(c.Cantidad_bonos) DESC
end

else
begin
--filtro por mes
INSERT INTO @Func
SELECT TOP 5 a.Nombre+' '+a.Apellido, SUM(c.Cantidad_bonos)
FROM TRIGGER_EXPLOSION.Compra c JOIN TRIGGER_EXPLOSION.Afiliado a ON a.Id_afiliado = c.Id_afiliado
	AND YEAR(c.Fecha) = @Anio
	AND MONTH(c.Fecha) = @Mes
group by a.Nombre+' '+a.Apellido
ORDER BY SUM(c.Cantidad_bonos) DESC
end


RETURN
END



-------------- ESPECIALIDADES CANCELADAS  --------
GO
CREATE FUNCTION TRIGGER_EXPLOSION.EspecialidadesCanceladas (@Semestre int, @Mes int, @Anio int)
RETURNS @Func TABLE(Especialidad varchar(255), Cancelaciones numeric(12,2))
AS

BEGIN
DECLARE @MaxMes int
DECLARE @MinMes int

if @Mes = 0
begin
--filtro por semestre

if @Semestre = 1
	begin 
	SET @MaxMes = 7
	SET @MinMes = 0
	end
	else
	begin 
	SET @MaxMes = 13
	SET @MinMes = 6
	end


INSERT INTO @Func
SELECT TOP 5 e.Descripcion, count(t.Cancelado)
FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Especialidad e ON t.Especialidad_id = e.Id_especialidad
	and t.Cancelado = 1
	AND YEAR(t.Fecha_programada) = @Anio
	AND MONTH(t.Fecha_programada) > @MinMes
	AND MONTH(t.Fecha_programada) < @MaxMes
	
group by e.Descripcion
ORDER BY count(t.Cancelado) DESC
end

else
begin
--filtro por mes
INSERT INTO @Func
SELECT TOP 5 e.Descripcion, count(t.Cancelado)
FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Especialidad e ON t.Especialidad_id = e.Id_especialidad
	and t.Cancelado = 1
	AND YEAR(t.Fecha_programada) = @Anio
	AND MONTH(t.Fecha_programada) = @Mes
group by e.Descripcion
ORDER BY count(t.Cancelado) DESC
end


RETURN
END
GO


-------------------- PROFESIONALES HORAS --------

GO
CREATE FUNCTION TRIGGER_EXPLOSION.ProfesionalesHoras (@Semestre int, @Mes int, @Anio int, @Especialidad numeric(18,0))
RETURNS @Func TABLE(Nombre varchar(255),Apellido varchar(255), HorasTrabajadas int)
AS
BEGIN
		DECLARE @ParametrosEspecialidad varchar(20)
		DECLARE @MaxMes int
		DECLARE @MinMes int


		IF (@Mes = 0)
		BEGIN
			IF (@Semestre = 1)
				begin
				SET @MaxMes = 13
				SET @MinMes = 6
				end
			ELSE
				begin
				SET @MaxMes = 7
				SET @MinMes = 0
				end
			IF(@Especialidad = 0)
				BEGIN
				--filtro por semestre y todas las especialidades
				INSERT INTO @Func
				SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno) /2

				FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
				WHERE YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada) > @MinMes and MONTH(t.Fecha_programada) < @MaxMes
				group by prof.Apellido, prof.Nombre
				ORDER BY COUNT(t.Id_turno)/2 ASC
				END
			ELSE
				BEGIN
			---- Filtro por semetre y especialidad
				INSERT INTO @Func
				SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno) /2

				FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
				WHERE YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada) > @MinMes and MONTH(t.Fecha_programada) < @MaxMes AND t.Especialidad_id = @Especialidad
				group by prof.Apellido, prof.Nombre
				ORDER BY COUNT(t.Id_turno)/2 ASC
				END
			END

		ELSE
			BEGIN
		--filtro por mes y todas las especialidades
			IF(@especialidad = 0)
				BEGIN
				INSERT INTO @Func
				SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)/2

				FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
				WHERE YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada)  = @Mes 
				group by prof.Apellido, prof.Nombre
				ORDER BY COUNT(t.Id_turno)/2 ASC
				END
			ELSE
				BEGIN
				INSERT INTO @Func
				SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)/2

				FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
				WHERE YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada)  = @Mes AND t.Especialidad_id = @Especialidad
				group by prof.Apellido, prof.Nombre
				ORDER BY COUNT(t.Id_turno)/2 ASC
				END
			END
RETURN
END


----- ------------------------------ PROFESIONALES CONSULTADOS -------------------------------------------
GO
CREATE FUNCTION TRIGGER_EXPLOSION.ProfesionalesConsultados (@Plan numeric(18,0), @Especialidad numeric(18,0), @Semestre int, 
						@Mes int, @Anio int)
RETURNS @Func TABLE(Nombre varchar(255),Apellido varchar(255), Consultas int)
AS
BEGIN

		DECLARE @MaxMes int
		DECLARE @MinMes int

		IF (@Mes = 0)
		begin
				IF (@Semestre = 1)
					begin
					SET @MaxMes = 7
					SET @MinMes = 0
					end
				ELSE IF(@Semestre = 2)
				begin
					SET @MaxMes = 13
					SET @MinMes = 6
				end

			-------------------------filtro por semestre----------------------------------------
			if (@Plan = 0 and @Especialidad = 0)
					--filtro para cualquier plan y especialidad
					begin 
					INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)

					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Id_afiliado = t.Id_afiliado 
					where  YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada) > @MinMes and MONTH(t.Fecha_programada) < @MaxMes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
					end

					else if (@Plan != 0 and @Especialidad=0)
					--filtro por un plan y cualquier especialidad
					begin
						INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)

					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Plan_id = @Plan and af.Id_afiliado = t.Id_afiliado 
					where YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada) > @MinMes and MONTH(t.Fecha_programada) < @MaxMes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
					 end

					 else if(@Plan = 0 and @Especialidad != 0)
					 --filtro por cualquier polan y una especialidad
					 begin
					INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)

					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON  af.Id_afiliado = t.Id_afiliado 
					where t.Especialidad_id  = @Especialidad and YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada) > @MinMes and MONTH(t.Fecha_programada) < @MaxMes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
					 end
					
					else if(@Plan != 0 and @Especialidad != 0)
					begin
					--filtro por ambos
						INSERT INTO @Func
						SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)
						FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
						JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Plan_id = @Plan and af.Id_afiliado = t.Id_afiliado 
						where t.Especialidad_id  = @Especialidad and YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada) > @MinMes and MONTH(t.Fecha_programada) < @MaxMes
						group by prof.Apellido, prof.Nombre
						ORDER BY COUNT(t.Id_turno) DESC
					end
			 --------------------------------------------------------
	

			end

		ELSE
		------------------filtro por mes----------------------------
		begin
		if(@Plan = 0 and @Especialidad = 0)
			begin
			--filtro para cualquier plan y especialidad
			INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)
					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Id_afiliado = t.Id_afiliado 
					where YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada)  = @Mes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
			end
		else if(@Plan != 0 and @Especialidad = 0)
			begin
			--filtro por un plan y cualquier especialidad
			INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)

					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Plan_id = @Plan and af.Id_afiliado = t.Id_afiliado 
					where  YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada)  = @Mes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
			end
		else if (@Plan = 0 and @Especialidad != 0)
			begin
			--filtro para cualquier  plan y una especialidad
			INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)

					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Id_afiliado = t.Id_afiliado 
					where t.Especialidad_id  = @Especialidad and YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada)  = @Mes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
			end

		else if(@Plan != 0 and @Especialidad != 0)
		--filtro por ambas
		begin
					INSERT INTO @Func
					SELECT TOP 5 prof.Apellido, prof.Nombre, COUNT(t.Id_turno)
					FROM TRIGGER_EXPLOSION.Turno t JOIN TRIGGER_EXPLOSION.Profesional prof ON t.Id_profesional = prof.Id_profesional
					JOIN TRIGGER_EXPLOSION.Afiliado af ON af.Plan_id = @Plan and af.Id_afiliado = t.Id_afiliado 
					where t.Especialidad_id  = @Especialidad and YEAR(t.Fecha_programada) = @Anio and MONTH(t.Fecha_programada)  = @Mes
					group by prof.Apellido, prof.Nombre
					ORDER BY COUNT(t.Id_turno) DESC
		end
		--
				
		end
	
RETURN
END


GO
CREATE FUNCTION TRIGGER_EXPLOSION.FX_get_Disponibilidad(@fecha datetime, @id_medico numeric(18,0), @id_especialidad numeric(18,0))
returns int
--Si el horario ya esta reservado para un turno devuelve 1, si esta libre devuelve 0, los turnos cancelados 
-- se consideran disponibles
AS

BEGIN
DECLARE @disponible int


SELECT @disponible =  COUNT(T.Id_turno) 
FROM TRIGGER_EXPLOSION.Turno T 
where T.Id_profesional = @id_medico AND T.Fecha_programada = @fecha AND T.Especialidad_id = @id_especialidad
	and t.Cancelado = 0

if @disponible > 0 
set @disponible = 0
else 
set @disponible = 1
return @disponible
END
GO

--devuelve todos los horarios para los que el profesional tiene un turno asignado a partir de fecha_desde inclusive
--excluye aquellos turnos que fueron cancelados
CREATE FUNCTION TRIGGER_EXPLOSION.getFechasDeTurnos (@profesional numeric(18,0), @fecha_desde varchar(20))
RETURNS @Func TABLE (Fecha datetime)
AS
BEGIN

INSERT INTO @Func
select t.Fecha_programada from TRIGGER_EXPLOSION.Turno t 
where t.Id_profesional = @profesional and DATEDIFF(d,CONVERT(DATETIME,@fecha_desde),t.Fecha_programada) >= 0
		and t.Cancelado = 0
	

RETURN
END

GO

--devuelve una lista de los IDS de agendas registradas bajo el profesional con una determinada especialidad
CREATE FUNCTION TRIGGER_EXPLOSION.getIdDeAgendasPorEspecialidad(@id_profesional numeric(18,0), @especialidad varchar(255), @fecha DATE)
RETURNS @Func TABLE (Id int)
AS
BEGIN
INSERT INTO @Func 
select Id_agenda from TRIGGER_EXPLOSION.Agenda 
where Id_profesional = @id_profesional 
AND Especialidad = @especialidad
AND @fecha < Fecha_fin
RETURN
END
GO



--Devuelve la cantidad de horas que trabaja el profesional por semana
--datediff devuelve negativo si startdate es mayor a enddate

CREATE FUNCTION TRIGGER_EXPLOSION.getHorasSemanales(@IdProfesional numeric(18,0), @fechaSistema varchar(255),
				 @fechaInicialNuevaAgenda varchar(255),
				@fechaFinalNuevaAgenda varchar(255))
RETURNS  int
AS
BEGIN
DECLARE @horas int

select @horas = (SUM(DATEDIFF(MINUTE,dd.inicio_jornada,dd.fin_jornada)) / 60)
 FROM TRIGGER_EXPLOSION.Dias_disponible dd JOIN TRIGGER_EXPLOSION.Agenda ag
  ON dd.Id_agenda = ag.Id_agenda and DATEDIFF(DAY,ag.Fecha_fin,CONVERT(DATETIME,@fechaSistema)) <=0  
  JOIN TRIGGER_EXPLOSION.Profesional p 
  ON ag.Id_profesional = p.Id_profesional
   and p.Id_profesional = 0 
   and dd.Dia != 'Domingo'
   and DATEDIFF(DAY,ag.Fecha_fin,CONVERT(DATETIME,@fechaInicialNuevaAgenda)) < 0 --fecha final de la agenda es mayor a la nueva
   and (
		DATEDIFF(DAY,ag.Fecha_inicio,CONVERT(DATETIME,@fechaInicialNuevaAgenda)) >= 0 --fecha de inicio menor o igual a la de la nueva agenda
		OR 
		--fecha de inicio de nueva agenda es menor a la fecha de inicio de la agenda, y la fecha de fin de nueva agenda es mayor 
		--a fecha de inicio de agenda, quiere decir que las fechas de las agendas se intersectan
			(DATEDIFF(DAY,ag.Fecha_inicio,CONVERT(DATETIME,@fechaInicialNuevaAgenda)) >=0 AND 
			DATEDIFF(DAY,ag.Fecha_inicio,CONVERT(DATETIME,@fechaFinalNuevaAgenda)) >=0)
		)
   
   group by p.Id_profesional

return @horas 
END
GO

