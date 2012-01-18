<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Ensayosrealizadosidu', 'doctrine');

/**
 * BaseEnsayosrealizadosidu
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $ensayosrealizadosidu_id
 * @property string $ensayosrealizadosidu_marca
 * @property string $ensayosrealizadosidu_modelo
 * @property string $ensayosrealizadosidu_codigo
 * @property string $ensayosrealizadosidu_serie
 * @property timestamp $ensayosrealizadosidu_fecha
 * @property integer $ensayosrealizadosidu_aprobado
 * @property string $ensayosrealizadosidu_dcf
 * @property integer $ensayosrealizadosidu_tiempoensayo
 * @property float $ensayosrealizadosidu_velocidadinicial
 * @property float $ensayosrealizadosidu_velocidadbajatension
 * @property float $ensayosrealizadosidu_velocidadlow
 * @property float $ensayosrealizadosidu_velocidadhigh
 * @property float $ensayosrealizadosidu_corrienteinicial
 * @property float $ensayosrealizadosidu_corrientebajatension
 * @property float $ensayosrealizadosidu_corrientelow
 * @property float $ensayosrealizadosidu_corrientehigh
 * @property float $ensayosrealizadosidu_corrientecalorinicial
 * @property string $ensayosrealizadosidu_hipot
 * @property string $ensayosrealizadosidu_fuga
 * @property string $ensayosrealizadosidu_observaciones
 * @property integer $ensayosrealizadosidu_cantidadreimpresion
 * @property string $ensayosrealizadosidu_usuario
 * @property string $orden_fabricacion
 * 
 * @method integer              getEnsayosrealizadosiduId()                     Returns the current record's "ensayosrealizadosidu_id" value
 * @method string               getEnsayosrealizadosiduMarca()                  Returns the current record's "ensayosrealizadosidu_marca" value
 * @method string               getEnsayosrealizadosiduModelo()                 Returns the current record's "ensayosrealizadosidu_modelo" value
 * @method string               getEnsayosrealizadosiduCodigo()                 Returns the current record's "ensayosrealizadosidu_codigo" value
 * @method string               getEnsayosrealizadosiduSerie()                  Returns the current record's "ensayosrealizadosidu_serie" value
 * @method timestamp            getEnsayosrealizadosiduFecha()                  Returns the current record's "ensayosrealizadosidu_fecha" value
 * @method integer              getEnsayosrealizadosiduAprobado()               Returns the current record's "ensayosrealizadosidu_aprobado" value
 * @method string               getEnsayosrealizadosiduDcf()                    Returns the current record's "ensayosrealizadosidu_dcf" value
 * @method integer              getEnsayosrealizadosiduTiempoensayo()           Returns the current record's "ensayosrealizadosidu_tiempoensayo" value
 * @method float                getEnsayosrealizadosiduVelocidadinicial()       Returns the current record's "ensayosrealizadosidu_velocidadinicial" value
 * @method float                getEnsayosrealizadosiduVelocidadbajatension()   Returns the current record's "ensayosrealizadosidu_velocidadbajatension" value
 * @method float                getEnsayosrealizadosiduVelocidadlow()           Returns the current record's "ensayosrealizadosidu_velocidadlow" value
 * @method float                getEnsayosrealizadosiduVelocidadhigh()          Returns the current record's "ensayosrealizadosidu_velocidadhigh" value
 * @method float                getEnsayosrealizadosiduCorrienteinicial()       Returns the current record's "ensayosrealizadosidu_corrienteinicial" value
 * @method float                getEnsayosrealizadosiduCorrientebajatension()   Returns the current record's "ensayosrealizadosidu_corrientebajatension" value
 * @method float                getEnsayosrealizadosiduCorrientelow()           Returns the current record's "ensayosrealizadosidu_corrientelow" value
 * @method float                getEnsayosrealizadosiduCorrientehigh()          Returns the current record's "ensayosrealizadosidu_corrientehigh" value
 * @method float                getEnsayosrealizadosiduCorrientecalorinicial()  Returns the current record's "ensayosrealizadosidu_corrientecalorinicial" value
 * @method string               getEnsayosrealizadosiduHipot()                  Returns the current record's "ensayosrealizadosidu_hipot" value
 * @method string               getEnsayosrealizadosiduFuga()                   Returns the current record's "ensayosrealizadosidu_fuga" value
 * @method string               getEnsayosrealizadosiduObservaciones()          Returns the current record's "ensayosrealizadosidu_observaciones" value
 * @method integer              getEnsayosrealizadosiduCantidadreimpresion()    Returns the current record's "ensayosrealizadosidu_cantidadreimpresion" value
 * @method string               getEnsayosrealizadosiduUsuario()                Returns the current record's "ensayosrealizadosidu_usuario" value
 * @method string               getOrdenFabricacion()                           Returns the current record's "orden_fabricacion" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduId()                     Sets the current record's "ensayosrealizadosidu_id" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduMarca()                  Sets the current record's "ensayosrealizadosidu_marca" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduModelo()                 Sets the current record's "ensayosrealizadosidu_modelo" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCodigo()                 Sets the current record's "ensayosrealizadosidu_codigo" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduSerie()                  Sets the current record's "ensayosrealizadosidu_serie" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduFecha()                  Sets the current record's "ensayosrealizadosidu_fecha" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduAprobado()               Sets the current record's "ensayosrealizadosidu_aprobado" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduDcf()                    Sets the current record's "ensayosrealizadosidu_dcf" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduTiempoensayo()           Sets the current record's "ensayosrealizadosidu_tiempoensayo" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduVelocidadinicial()       Sets the current record's "ensayosrealizadosidu_velocidadinicial" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduVelocidadbajatension()   Sets the current record's "ensayosrealizadosidu_velocidadbajatension" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduVelocidadlow()           Sets the current record's "ensayosrealizadosidu_velocidadlow" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduVelocidadhigh()          Sets the current record's "ensayosrealizadosidu_velocidadhigh" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCorrienteinicial()       Sets the current record's "ensayosrealizadosidu_corrienteinicial" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCorrientebajatension()   Sets the current record's "ensayosrealizadosidu_corrientebajatension" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCorrientelow()           Sets the current record's "ensayosrealizadosidu_corrientelow" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCorrientehigh()          Sets the current record's "ensayosrealizadosidu_corrientehigh" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCorrientecalorinicial()  Sets the current record's "ensayosrealizadosidu_corrientecalorinicial" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduHipot()                  Sets the current record's "ensayosrealizadosidu_hipot" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduFuga()                   Sets the current record's "ensayosrealizadosidu_fuga" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduObservaciones()          Sets the current record's "ensayosrealizadosidu_observaciones" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduCantidadreimpresion()    Sets the current record's "ensayosrealizadosidu_cantidadreimpresion" value
 * @method Ensayosrealizadosidu setEnsayosrealizadosiduUsuario()                Sets the current record's "ensayosrealizadosidu_usuario" value
 * @method Ensayosrealizadosidu setOrdenFabricacion()                           Sets the current record's "orden_fabricacion" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseEnsayosrealizadosidu extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('ensayosrealizadosidu');
        $this->hasColumn('ensayosrealizadosidu_id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('ensayosrealizadosidu_marca', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_modelo', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_codigo', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_serie', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_fecha', 'timestamp', 25, array(
             'type' => 'timestamp',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0000-00-00 00:00:00',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 25,
             ));
        $this->hasColumn('ensayosrealizadosidu_aprobado', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
        $this->hasColumn('ensayosrealizadosidu_dcf', 'string', 10, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 10,
             ));
        $this->hasColumn('ensayosrealizadosidu_tiempoensayo', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('ensayosrealizadosidu_velocidadinicial', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_velocidadbajatension', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_velocidadlow', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_velocidadhigh', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_corrienteinicial', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_corrientebajatension', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_corrientelow', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_corrientehigh', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_corrientecalorinicial', 'float', null, array(
             'type' => 'float',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => '',
             ));
        $this->hasColumn('ensayosrealizadosidu_hipot', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_fuga', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_observaciones', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('ensayosrealizadosidu_cantidadreimpresion', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('ensayosrealizadosidu_usuario', 'string', 45, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 45,
             ));
        $this->hasColumn('orden_fabricacion', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => 'N/D',
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        
    }
}