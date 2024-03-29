<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Ensayo', 'pcb');

/**
 * BaseEnsayo
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property string $nombre
 * @property Doctrine_Collection $Ensayoparametro
 * @property Doctrine_Collection $Placa
 * 
 * @method integer             getId()              Returns the current record's "id" value
 * @method string              getNombre()          Returns the current record's "nombre" value
 * @method Doctrine_Collection getEnsayoparametro() Returns the current record's "Ensayoparametro" collection
 * @method Doctrine_Collection getPlaca()           Returns the current record's "Placa" collection
 * @method Ensayo              setId()              Sets the current record's "id" value
 * @method Ensayo              setNombre()          Sets the current record's "nombre" value
 * @method Ensayo              setEnsayoparametro() Sets the current record's "Ensayoparametro" collection
 * @method Ensayo              setPlaca()           Sets the current record's "Placa" collection
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseEnsayo extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('ensayo');
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
        $this->hasMany('Ensayoparametro', array(
             'local' => 'id',
             'foreign' => 'ensayoid'));

        $this->hasMany('Placa', array(
             'local' => 'id',
             'foreign' => 'ensayoid'));
    }
}