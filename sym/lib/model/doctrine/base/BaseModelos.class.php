<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Modelos', 'doctrine');

/**
 * BaseModelos
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $modelos_id
 * @property string $modelos_marca
 * @property string $modelos_modelo
 * @property string $modelos_codigo
 * @property string $modelos_referencia
 * @property string $modelos_ean13
 * @property integer $modelos_etiqueta
 * @property integer $modelos_etiquetacaja
 * @property string $modelos_logo
 * @property string $modelos_conjunto
 * @property string $modelos_capacidad
 * @property string $modelos_codigoicsa
 * @property string $modelos_descripcion
 * @property string $modelos_dimensiones
 * @property integer $modelos_esidu
 * @property integer $es_activo
 * @property string $background_bulto
 * @property string $background_producto
 * @property Caracteristicastecnicasequipos $Caracteristicastecnicasequipos
 * 
 * @method integer                        getModelosId()                      Returns the current record's "modelos_id" value
 * @method string                         getModelosMarca()                   Returns the current record's "modelos_marca" value
 * @method string                         getModelosModelo()                  Returns the current record's "modelos_modelo" value
 * @method string                         getModelosCodigo()                  Returns the current record's "modelos_codigo" value
 * @method string                         getModelosReferencia()              Returns the current record's "modelos_referencia" value
 * @method string                         getModelosEan13()                   Returns the current record's "modelos_ean13" value
 * @method integer                        getModelosEtiqueta()                Returns the current record's "modelos_etiqueta" value
 * @method integer                        getModelosEtiquetacaja()            Returns the current record's "modelos_etiquetacaja" value
 * @method string                         getModelosLogo()                    Returns the current record's "modelos_logo" value
 * @method string                         getModelosConjunto()                Returns the current record's "modelos_conjunto" value
 * @method string                         getModelosCapacidad()               Returns the current record's "modelos_capacidad" value
 * @method string                         getModelosCodigoicsa()              Returns the current record's "modelos_codigoicsa" value
 * @method string                         getModelosDescripcion()             Returns the current record's "modelos_descripcion" value
 * @method string                         getModelosDimensiones()             Returns the current record's "modelos_dimensiones" value
 * @method integer                        getModelosEsidu()                   Returns the current record's "modelos_esidu" value
 * @method integer                        getEsActivo()                       Returns the current record's "es_activo" value
 * @method string                         getBackgroundBulto()                Returns the current record's "background_bulto" value
 * @method string                         getBackgroundProducto()             Returns the current record's "background_producto" value
 * @method Caracteristicastecnicasequipos getCaracteristicastecnicasequipos() Returns the current record's "Caracteristicastecnicasequipos" value
 * @method Modelos                        setModelosId()                      Sets the current record's "modelos_id" value
 * @method Modelos                        setModelosMarca()                   Sets the current record's "modelos_marca" value
 * @method Modelos                        setModelosModelo()                  Sets the current record's "modelos_modelo" value
 * @method Modelos                        setModelosCodigo()                  Sets the current record's "modelos_codigo" value
 * @method Modelos                        setModelosReferencia()              Sets the current record's "modelos_referencia" value
 * @method Modelos                        setModelosEan13()                   Sets the current record's "modelos_ean13" value
 * @method Modelos                        setModelosEtiqueta()                Sets the current record's "modelos_etiqueta" value
 * @method Modelos                        setModelosEtiquetacaja()            Sets the current record's "modelos_etiquetacaja" value
 * @method Modelos                        setModelosLogo()                    Sets the current record's "modelos_logo" value
 * @method Modelos                        setModelosConjunto()                Sets the current record's "modelos_conjunto" value
 * @method Modelos                        setModelosCapacidad()               Sets the current record's "modelos_capacidad" value
 * @method Modelos                        setModelosCodigoicsa()              Sets the current record's "modelos_codigoicsa" value
 * @method Modelos                        setModelosDescripcion()             Sets the current record's "modelos_descripcion" value
 * @method Modelos                        setModelosDimensiones()             Sets the current record's "modelos_dimensiones" value
 * @method Modelos                        setModelosEsidu()                   Sets the current record's "modelos_esidu" value
 * @method Modelos                        setEsActivo()                       Sets the current record's "es_activo" value
 * @method Modelos                        setBackgroundBulto()                Sets the current record's "background_bulto" value
 * @method Modelos                        setBackgroundProducto()             Sets the current record's "background_producto" value
 * @method Modelos                        setCaracteristicastecnicasequipos() Sets the current record's "Caracteristicastecnicasequipos" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseModelos extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('modelos');
        $this->hasColumn('modelos_id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('modelos_marca', 'string', 30, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 30,
             ));
        $this->hasColumn('modelos_modelo', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_codigo', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_referencia', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_ean13', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_etiqueta', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('modelos_etiquetacaja', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('modelos_logo', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_conjunto', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_capacidad', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_codigoicsa', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_descripcion', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_dimensiones', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '"',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('modelos_esidu', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '1',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
        $this->hasColumn('es_activo', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '1',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('background_bulto', 'string', 45, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 45,
             ));
        $this->hasColumn('background_producto', 'string', 45, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 45,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        $this->hasOne('Caracteristicastecnicasequipos', array(
             'local' => 'modelos_referencia',
             'foreign' => 'caracteristicastecnicasequipos_nombre'));
    }
}