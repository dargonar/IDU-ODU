<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Fallasodu', 'doctrine');

/**
 * BaseFallasodu
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $numerodefalla
 * @property string $descripcion
 * @property integer $prioridadalta
 * @property integer $es_falla_controlada
 * 
 * @method integer   getNumerodefalla()       Returns the current record's "numerodefalla" value
 * @method string    getDescripcion()         Returns the current record's "descripcion" value
 * @method integer   getPrioridadalta()       Returns the current record's "prioridadalta" value
 * @method integer   getEsFallaControlada()   Returns the current record's "es_falla_controlada" value
 * @method Fallasodu setNumerodefalla()       Sets the current record's "numerodefalla" value
 * @method Fallasodu setDescripcion()         Sets the current record's "descripcion" value
 * @method Fallasodu setPrioridadalta()       Sets the current record's "prioridadalta" value
 * @method Fallasodu setEsFallaControlada()   Sets the current record's "es_falla_controlada" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseFallasodu extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('fallasodu');
        $this->hasColumn('numerodefalla', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('descripcion', 'string', 100, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 100,
             ));
        $this->hasColumn('prioridadalta', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
        $this->hasColumn('es_falla_controlada', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => false,
             'default' => '0',
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