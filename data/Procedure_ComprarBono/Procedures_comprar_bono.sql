
CREATE PROCEDURE TRIGGER_EXPLOSION.comprarBonos
	(@id_afiliado NUMERIC(18, 0),
	 @cantidad NUMERIC(5,0),
	 @precioTotal NUMERIC(18,4))

AS

BEGIN
	CREATE TABLE #id_compra (id_compra NUMERIC(18,0));
	DECLARE @Fecha DATETIME = GETDATE();
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