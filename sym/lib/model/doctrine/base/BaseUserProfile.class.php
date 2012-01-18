<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('UserProfile', 'doctrine');

/**
 * BaseUserProfile
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property integer $sf_guard_user_id
 * @property string $numero_legajo
 * @property string $phone
 * @property string $turno
 * @property string $puesto
 * @property string $linea
 * @property timestamp $created_at
 * @property timestamp $updated_at
 * @property sfGuardUser $User
 * 
 * @method integer     getId()               Returns the current record's "id" value
 * @method integer     getSfGuardUserId()    Returns the current record's "sf_guard_user_id" value
 * @method string      getNumeroLegajo()     Returns the current record's "numero_legajo" value
 * @method string      getPhone()            Returns the current record's "phone" value
 * @method string      getTurno()            Returns the current record's "turno" value
 * @method string      getPuesto()           Returns the current record's "puesto" value
 * @method string      getLinea()            Returns the current record's "linea" value
 * @method timestamp   getCreatedAt()        Returns the current record's "created_at" value
 * @method timestamp   getUpdatedAt()        Returns the current record's "updated_at" value
 * @method sfGuardUser getUser()             Returns the current record's "User" value
 * @method UserProfile setId()               Sets the current record's "id" value
 * @method UserProfile setSfGuardUserId()    Sets the current record's "sf_guard_user_id" value
 * @method UserProfile setNumeroLegajo()     Sets the current record's "numero_legajo" value
 * @method UserProfile setPhone()            Sets the current record's "phone" value
 * @method UserProfile setTurno()            Sets the current record's "turno" value
 * @method UserProfile setPuesto()           Sets the current record's "puesto" value
 * @method UserProfile setLinea()            Sets the current record's "linea" value
 * @method UserProfile setCreatedAt()        Sets the current record's "created_at" value
 * @method UserProfile setUpdatedAt()        Sets the current record's "updated_at" value
 * @method UserProfile setUser()             Sets the current record's "User" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseUserProfile extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('user_profile');
        $this->hasColumn('id', 'integer', 8, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => true,
             'autoincrement' => true,
             'length' => 8,
             ));
        $this->hasColumn('sf_guard_user_id', 'integer', 8, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 8,
             ));
        $this->hasColumn('numero_legajo', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('phone', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('turno', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('puesto', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('linea', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('created_at', 'timestamp', 25, array(
             'type' => 'timestamp',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 25,
             ));
        $this->hasColumn('updated_at', 'timestamp', 25, array(
             'type' => 'timestamp',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 25,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        $this->hasOne('sfGuardUser as User', array(
             'local' => 'sf_guard_user_id',
             'foreign' => 'id',
             'onDelete' => 'cascade'));

        $timestampable0 = new Doctrine_Template_Timestampable(array(
             ));
        $this->actAs($timestampable0);
    }
}