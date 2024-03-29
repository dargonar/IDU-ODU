<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Usuarios', 'doctrine');

/**
 * BaseUsuarios
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $usuarios_id
 * @property string $usuarios_password
 * @property string $usuarios_descripcion
 * 
 * @method integer  getUsuariosId()           Returns the current record's "usuarios_id" value
 * @method string   getUsuariosPassword()     Returns the current record's "usuarios_password" value
 * @method string   getUsuariosDescripcion()  Returns the current record's "usuarios_descripcion" value
 * @method Usuarios setUsuariosId()           Sets the current record's "usuarios_id" value
 * @method Usuarios setUsuariosPassword()     Sets the current record's "usuarios_password" value
 * @method Usuarios setUsuariosDescripcion()  Sets the current record's "usuarios_descripcion" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseUsuarios extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('usuarios');
        $this->hasColumn('usuarios_id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('usuarios_password', 'string', 20, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '""',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 20,
             ));
        $this->hasColumn('usuarios_descripcion', 'string', 45, array(
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
        
    }
}