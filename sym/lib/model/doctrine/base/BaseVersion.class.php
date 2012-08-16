<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Version', 'pcb');

/**
 * BaseVersion
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property string $descripcion
 * @property integer $plc
 * @property Doctrine_Collection $Placa
 * 
 * @method integer             getId()          Returns the current record's "id" value
 * @method string              getDescripcion() Returns the current record's "descripcion" value
 * @method integer             getPlc()         Returns the current record's "plc" value
 * @method Doctrine_Collection getPlaca()       Returns the current record's "Placa" collection
 * @method Version             setId()          Sets the current record's "id" value
 * @method Version             setDescripcion() Sets the current record's "descripcion" value
 * @method Version             setPlc()         Sets the current record's "plc" value
 * @method Version             setPlaca()       Sets the current record's "Placa" collection
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseVersion extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('version');
        $this->hasColumn('id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('descripcion', 'string', 128, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 128,
             ));
        $this->hasColumn('plc', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        $this->hasMany('Placa', array(
             'local' => 'id',
             'foreign' => 'versionid'));
    }
}