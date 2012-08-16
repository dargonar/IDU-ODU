<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Etiqueta', 'pcb');

/**
 * BaseEtiqueta
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property string $nombre
 * @property Doctrine_Collection $Itemetiqueta
 * @property Doctrine_Collection $Placa
 * 
 * @method integer             getId()           Returns the current record's "id" value
 * @method string              getNombre()       Returns the current record's "nombre" value
 * @method Doctrine_Collection getItemetiqueta() Returns the current record's "Itemetiqueta" collection
 * @method Doctrine_Collection getPlaca()        Returns the current record's "Placa" collection
 * @method Etiqueta            setId()           Sets the current record's "id" value
 * @method Etiqueta            setNombre()       Sets the current record's "nombre" value
 * @method Etiqueta            setItemetiqueta() Sets the current record's "Itemetiqueta" collection
 * @method Etiqueta            setPlaca()        Sets the current record's "Placa" collection
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseEtiqueta extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('etiqueta');
        $this->hasColumn('id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('nombre', 'string', 128, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 128,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        $this->hasMany('Itemetiqueta', array(
             'local' => 'id',
             'foreign' => 'etiquetaid'));

        $this->hasMany('Placa', array(
             'local' => 'id',
             'foreign' => 'etiquetaid'));
    }
}