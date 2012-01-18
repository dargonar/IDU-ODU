<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Reimpresiones', 'doctrine');

/**
 * BaseReimpresiones
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $reimpresiones_id
 * @property string $reimpresiones_marca
 * @property string $reimpresiones_modelo
 * @property string $reimpresiones_codigo
 * @property string $reimpresiones_serie
 * @property timestamp $reimpresiones_fecha
 * @property integer $reimpresiones_aprobado
 * @property string $reimpresiones_observaciones
 * @property integer $reimpresiones_esidu
 * 
 * @method integer       getReimpresionesId()             Returns the current record's "reimpresiones_id" value
 * @method string        getReimpresionesMarca()          Returns the current record's "reimpresiones_marca" value
 * @method string        getReimpresionesModelo()         Returns the current record's "reimpresiones_modelo" value
 * @method string        getReimpresionesCodigo()         Returns the current record's "reimpresiones_codigo" value
 * @method string        getReimpresionesSerie()          Returns the current record's "reimpresiones_serie" value
 * @method timestamp     getReimpresionesFecha()          Returns the current record's "reimpresiones_fecha" value
 * @method integer       getReimpresionesAprobado()       Returns the current record's "reimpresiones_aprobado" value
 * @method string        getReimpresionesObservaciones()  Returns the current record's "reimpresiones_observaciones" value
 * @method integer       getReimpresionesEsidu()          Returns the current record's "reimpresiones_esidu" value
 * @method Reimpresiones setReimpresionesId()             Sets the current record's "reimpresiones_id" value
 * @method Reimpresiones setReimpresionesMarca()          Sets the current record's "reimpresiones_marca" value
 * @method Reimpresiones setReimpresionesModelo()         Sets the current record's "reimpresiones_modelo" value
 * @method Reimpresiones setReimpresionesCodigo()         Sets the current record's "reimpresiones_codigo" value
 * @method Reimpresiones setReimpresionesSerie()          Sets the current record's "reimpresiones_serie" value
 * @method Reimpresiones setReimpresionesFecha()          Sets the current record's "reimpresiones_fecha" value
 * @method Reimpresiones setReimpresionesAprobado()       Sets the current record's "reimpresiones_aprobado" value
 * @method Reimpresiones setReimpresionesObservaciones()  Sets the current record's "reimpresiones_observaciones" value
 * @method Reimpresiones setReimpresionesEsidu()          Sets the current record's "reimpresiones_esidu" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseReimpresiones extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('reimpresiones');
        $this->hasColumn('reimpresiones_id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('reimpresiones_marca', 'string', 20, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 20,
             ));
        $this->hasColumn('reimpresiones_modelo', 'string', 30, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 30,
             ));
        $this->hasColumn('reimpresiones_codigo', 'string', 30, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 30,
             ));
        $this->hasColumn('reimpresiones_serie', 'string', 20, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 20,
             ));
        $this->hasColumn('reimpresiones_fecha', 'timestamp', 25, array(
             'type' => 'timestamp',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 25,
             ));
        $this->hasColumn('reimpresiones_aprobado', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
        $this->hasColumn('reimpresiones_observaciones', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('reimpresiones_esidu', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        
    }
}