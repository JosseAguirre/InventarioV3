SELECT COUNT(INVENTARIO.ingresoComputadores.CODIGOINTERNO) AS EquiposAsignardos FROM INVENTARIO.asignacionComputadores
INNER JOIN INVENTARIO.ingresoComputadores ON INVENTARIO.ingresoComputadores.CODIGOINTERNO = INVENTARIO.asignacionComputadores.CODIGOINTERNO
WHERE INVENTARIO.asignacionComputadores.CODIGOINTERNO = INVENTARIO.ingresoComputadores.CODIGOINTERNO 

 -- TRUNCATE TABLE INVENTARIO.asignacionComputadores;

 --SELECT  COUNT(INVENTARIO.ingresoComputadores.CODIGOINTERNO) AS EquiposSinAsignar FROM INVENTARIO.ingresoComputadores
 --INNER JOIN INVENTARIO.asignacionComputadores ON INVENTARIO.asignacionComputadores.CODIGOINTERNO != INVENTARIO.ingresoComputadores.CODIGOINTERNO
 --WHERE INVENTARIO.ingresoComputadores.CODIGOINTERNO != INVENTARIO.asignacionComputadores.CODIGOINTERNO;

--SELECT COUNT(INVENTARIO.asignacionComputadores.SECUENCIAL) AS ComputadoresAsignados, COUNT(INVENTARIO.ingresoComputadores.SECUENCIAL) AS TotalCompuadores
--FROM INVENTARIO.asignacionComputadores 
--FULL OUTER JOIN INVENTARIO.ingresoComputadores ON INVENTARIO.asignacionComputadores.SECUENCIAL = INVENTARIO.ingresoComputadores.SECUENCIAL;