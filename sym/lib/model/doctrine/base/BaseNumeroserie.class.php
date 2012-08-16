<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Numeroserie', 'pcb');

/**
 * BaseNumeroserie
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property string $tipo
 * @property integer $numero
 * @property integer $maximo
 * @property integer $minimo
 * @property string $prefijo
 * @property integer $sufijo
 * 
 * @method integer     getId()      Returns the current record's "id" value
 * @method string      getTipo()    Returns the current record's "tipo" value
 * @method integer     getNumero()  Returns the current record's "numero" value
 * @method integer     getMaximo()  Returns the current record's "maximo" value
 * @method integer     getMinimo()  Returns the current record's "minimo" value
 * @method string      getPrefijo() Returns the current record's "prefijo" value
 * @method integer     getSufijo()  Returns the current record's "sufijo" value
 * @method Numeroserie setId()      Sets the current record's "id" value
 * @method Numeroserie setTipo()    Sets the current record's "tipo" value
 * @method Numeroserie setNumero()  Sets the current record's "numero" value
 * @method Numeroserie setMaximo()  Sets the current record's "maximo" value
 * @method Numeroserie setMinimo()  Sets the current record's "minimo" value
 * @method Numeroserie setPrefijo() Sets the current record's "prefijo" value
 * @method Numeroserie setSufijo()  Sets the current record's "sufijo" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseNumeroserie extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('numeroserie');
        $this->hasColumn('id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('tipo', 'string', 1, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
        $this->hasColumn('numero', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('maximo', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('minimo', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('prefijo', 'string', 10, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 10,
             ));
        $this->hasColumn('sufijo', 'integer', 4, array(
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
        
    }
}