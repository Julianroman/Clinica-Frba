----------------------------------------------------------------------
-----------------------turnos_dia_siguiente---------------------------
----------------------------------------------------------------------
CREATE PROCEDURE TRIGGER_EXPLOSION.turnos_dia_siguiente
	(@username varchar(255))

AS

BEGIN

	SELECT t.Id_turno Turno, p.Nombre + ' ' + p.Apellido Medico, e.Descripcion Especialidad, t.Fecha_programada Fecha
	FROM TRIGGER_EXPLOSION.Turno t
	JOIN TRIGGER_EXPLOSION.Profesional P ON (t.Id_profesional = p.Id_profesional)
	JOIN TRIGGER_EXPLOSION.Especialidad E ON (e.Id_especialidad = T.Especialidad_id)
	JOIN TRIGGER_EXPLOSION.Afiliado A ON (a.Id_afiliado = t.Id_afiliado)
	JOIN TRIGGER_EXPLOSION.Usuario U on (u.Id_usuario = a.Id_usuario)
	WHERE u.Username = @username AND (DATEDIFF(day,t.Fecha_programada,GETDATE()) <= 1)
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
		WHERE CONVERT(DATE,@fecha) = CONVERT(DATE,Fecha_programada)

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


