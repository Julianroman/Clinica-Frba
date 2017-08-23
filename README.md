# GDD2C2016
Repo para el trabajo practico de la Cátedra Gestión de Datos de la Universidad Tecnológica Nacional Buenos Aires
<a href="https://drive.google.com/drive/u/1/folders/0B4_o00zOj2BeckJuemJERjZ2Vmc"> Drive del Grupo </a>

<h2>Alumnos:</h2>
<i>Federico Torres</i><br>
<i>Melania Miranda</i><br>
<i>Juan Biltes</i><br>
<i>Julian Roman</i><br>


## Notas

<h2>Estrategias de Diseño</h2>
<p>
<b>1)</b>Tomamos como una semana de lunes a sabado <br>
<b>2)</b>En la agenda del medico para seleccionar el rango de fechas disponible tomamos como referencia dos fechas: desde que comienza a estar disponible hasta que deja de estar disponible (CONSULTAR ESTO)<br>
<b>3)</b>Para la migracion de usuarios tomamos como username el DNI de los pacientes y medicos ya que es lo unico que los diferencia univocamente<br>
<b>4)</b>Consulta Medica y Turno comparten el mismo ID<br>
<b>5)</b>Diseño de la agenda: La tabla Dias disponible indica para cada dia de la semana en que rango horario atiende el medico y con que especialidad, puede repetirse el dia de la semana para un mismo medico si cambia la especialidad. La tabla de horarios por dia indica el horario de un turno, y el id del mismo, asi sabemos en que horarios el medico tiene turnos asignados<br>
<b>5)</b>Afiliado almacena un contador de cantidad de consultas medicas, cuando se concreta una consulta se setea en el bono la consulta medica y se actualiza el contador en el afiliado<br>


</p>


<h2>---------------Verificar antes de la entrega-------------------------------</h2>
<p>
<b>1)</b> Que se cree un usuario 'admin' con password w23e (IMPORTANTE) <br>
<b>2)</b>Las passwords encriptadas en SHA256<br>
<b>3) </b>Nombre, apellido dni y fecha de nacimiento son inmodificables<br>
<b>4)</b>Todos los cambios de planes deben ser registrados con motivo y debe poder accederse al historial desde la app<br>
<b>5)</b>Un profesional no puede tener mas de 48 hs asignadas por semana<br>
<b>6)</b>Respetar y revisar estructura de entrega con el <b>pdf</b> de Estrategias indicando DER, SPs, Indices, triggers, vistas, etc. <br>
<b>7)</b>Chequear constraint en base de datos, no se deben poder ingresar horarios de la agenda de un medico fuera del horario de apertura de la clinica (7am a 8pm para la semana y los sabados de 10 am a 15 pm)<br>
<b>8)</b>Verificar que en la compra de bonos el afiliado este activo<br>
<b>9)</b>Testear que no se asigne un turno fuera de la agenda del profesional y de la especialidad<br>
</p>



--------------------------Dudas---------------
1)Compra de bonos: ¿Cuando un afiliado esta inactivo ?<br>

