---------------------- Especialidades Bonos ---------------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TRIGGER_EXPLOSION.EspecialidadesBonos (@Semestre int, @Mes int, @Año int)
AS
BEGIN

		DECLARE @parametros varchar(5)

		IF (@Mes = 0)
			IF (@Semestre = 1)
				SET @Parametros = '< 6'
			ELSE
				SET @Parametros = '> 6'
		ELSE
			SET @Parametros = '= ' + CAST(@Mes AS varchar(2))

		EXEC('SELECT TOP 5 Especialidad_id, count(Id_turno) as ''Cantidad de bonos usados'', e.Descripcion 
			FROM TRIGGER_EXPLOSION.Turno t
			join TRIGGER_EXPLOSION.Especialidad e ON e.Id_especialidad = t.Especialidad_id
			where YEAR(t.Fecha_programada) = 2015

		WHERE YEAR(t.Fecha_programada) = '+@Año+'
			AND MONTH(t.Fecha_programada) '+@Parametros+'

		GROUP BY Especialidad_id, e.Descripcion
		ORDER BY COUNT(Id_turno) DESC')
END


------------------ AFILIADOS BONOS ---------------

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TRIGGER_EXPLOSION.AfiliadosBonos (@Semestre int, @Mes int, @Año int)
AS
BEGIN


		DECLARE @parametros varchar(5)

		IF (@Mes = 0)
			IF (@Semestre = 1)
				SET @Parametros = '< 6'
			ELSE
				SET @Parametros = '> 6'
		ELSE
			SET @Parametros = '= ' + CAST(@Mes AS varchar(2))


		EXEC('SELECT TOP 5 af.Nombre, af.Apellido , SUM(cantidad_bonos) as ''cantidad bonos comprados'' 
			from TRIGGER_EXPLOSION.Compra c
			left join TRIGGER_EXPLOSION.Afiliado af on af.Id_afiliado =  c.Id_afiliado
		WHERE YEAR(c.Fecha) = '+@Año+'
			AND MONTH(c.Fecha) '+@Parametros+'

		GROUP BY af.Nombre, af.Apellido
		ORDER BY [cantidad bonos comprados] DESC')				
END

-------------- ESPECIALIDADES CANCELADAS  --------

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TRIGGER_EXPLOSION.EspecialidadesCanceladas (@Semestre int, @Mes int, @Año int)
AS
BEGIN

	DECLARE @parametros varchar(5)

	IF (@Mes = 0)
		IF (@Semestre = 1)
			SET @Parametros = '< 6'
		ELSE
			SET @Parametros = '> 6'
	ELSE
		SET @Parametros = '= ' + CAST(@Mes AS varchar(2))
		
	EXEC('SELECT TOP 5 e.Descripcion, count(t.Cancelado) as ''Cantidad de veces cancelada''  FROM TRIGGER_EXPLOSION.Turno t
		join TRIGGER_EXPLOSION.Especialidad e ON e.Id_especialidad = t.Especialidad_id
		WHERE t.Cancelado is not null
			AND YEAR(t.Fecha_programada) = '+@Año+'
			AND MONTH(t.Fecha_programada) = '+@Parametros+'
		GROUP BY e.Descripcion
		ORDER BY count(t.Cancelado) desc')	
		
END

-------------------- PROFESIONALES HORAS --------

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TRIGGER_EXPLOSION.ProfesionalesHoras (@Especialidad numeric(18,0), @Semestre int, @Mes int, @Año int)
AS
BEGIN

		DECLARE @parametros varchar(5)
		DECLARE @parametrosEspecialidad varchar(20)

		IF (@Mes = 0)
			IF (@Semestre = 1)
				SET @Parametros = '< 6'
			ELSE
				SET @Parametros = '> 6'
		ELSE
			SET @Parametros = '= ' + CAST(@Mes AS varchar(2))

		IF (@Especialidad = 0)
			SET @ParametrosEspecialidad = ''
		ELSE
			SET @ParametrosEspecialidad = ' AND e.Id_especialidad = ' + CAST(@Especialidad AS varchar(18))


		EXEC('select top 5 DATEDIFF(hour,Fecha_inicio,Fecha_fin) as ''Horas trabajadas'', p.Nombre +'' ''+p.Apellido as ''Profesional'', e.Descripcion
				from TRIGGER_EXPLOSION.Agenda a
				join TRIGGER_EXPLOSION.Profesional p ON p.Id_profesional = a.Id_profesional
				join TRIGGER_EXPLOSION.Especialidad e ON e.Descripcion = a.Especialidad
		WHERE 
			YEAR(a.Fecha_fin) = '+@Año+'
			AND MONTH(a.Fecha_fin) '+ @Parametros +'
			'+@ParametrosEspecialidad+'

		ORDER BY [Horas trabajadas] ASC')
				
END


----- ------------------------------ PROFESIONALES CONSULTADOS -------------------------------------------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TRIGGER_EXPLOSION.ProfesionalesConsultados (@Plan numeric(18,0), @Especialidad numeric(18,0), @Semestre int, @Mes int, @Año int)
AS
BEGIN

		DECLARE @parametros varchar(5)
		DECLARE @parametrosPlan varchar(20)
		DECLARE @parametrosEspecialidad varchar(20)

		IF (@Mes = 0)
			IF (@Semestre = 1)
				SET @Parametros = '< 6'
			ELSE
				SET @Parametros = '> 6'
		ELSE
			SET @Parametros = '= ' + CAST(@Mes AS varchar(2))

		IF (@Plan = 0)
			SET @ParametrosPlan = ''
		ELSE
			SET @ParametrosPlan = ' AND a.Plan_id = ' + CAST(@Plan AS varchar(18))
	
		IF (@Especialidad = 0)
			SET @ParametrosEspecialidad = ''
		ELSE
			SET @ParametrosEspecialidad = ' AND e.Id_especialidad = ' + CAST(@Especialidad AS varchar(18))


		EXEC('Select  top 5 pro.Nombre + '' '' + pro.Apellido as ''Profesional'',p.Descripcion as ''PLAN'', e.Descripcion as ''ESPECIALIDAD'', count(t.Id_turno) as ''Cantidad de turnos''
				from TRIGGER_EXPLOSION.Turno t
				join TRIGGER_EXPLOSION.Profesional pro ON pro.Id_profesional = t.Id_profesional
				join TRIGGER_EXPLOSION.Especialidad e ON e.Id_especialidad = t.Especialidad_id
				join TRIGGER_EXPLOSION.Afiliado a ON a.Id_afiliado = t.Id_afiliado
				join TRIGGER_EXPLOSION.PlanMedico p ON p.Id_plan = a.Plan_id
 
		WHERE 
			YEAR(Agen_Fecha) = '+@Año+'
			AND MONTH(Agen_Fecha) '+@Parametros+'
			'+@ParametrosPlan+@ParametrosEspecialidad+'


		GROUP BY p.Descripcion, e.Descripcion, pro.Nombre + ' ' + pro.Apellido
		ORDER BY COUNT(t.Id_turno) DESC')
				
	
END
