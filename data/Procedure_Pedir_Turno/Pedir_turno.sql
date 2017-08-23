CREATE FUNCTION TRIGGER_EXPLOSION.FX_get_Disponibilidad( @fecha datetime, @id_medico numeric(18,0), @id_especialidad numeric(18,0))
returns int
--Si el horario ya esta reservado para un turno devuelve 1, si esta libre devuelve 0
AS

BEGIN
DECLARE @disponible int


SELECT @disponible =  COUNT(T.Id_turno) 
FROM TRIGGER_EXPLOSION.Turno T 
where T.Id_profesional = @id_medico AND T.Fecha_programada = @fecha AND T.Especialidad_id = @id_especialidad


if @disponible > 0 
set @disponible = 0
else 
set @disponible = 1
return @disponible
END
GO
