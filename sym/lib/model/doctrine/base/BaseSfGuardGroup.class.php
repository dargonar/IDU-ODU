<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('SfGuardGroup', 'doctrine');

/**
 * BaseSfGuardGroup
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property string $name
 * @property string $description
 * @property timestamp $created_at
 * @property timestamp $updated_at
 * @property Doctrine_Collection $SfGuardGroupPermission
 * @property Doctrine_Collection $SfGuardUserGroup
 * 
 * @method integer             getId()                     Returns the current record's "id" value
 * @method string              getName()                   Returns the current record's "name" value
 * @method string              getDescription()            Returns the current record's "description" value
 * @method timestamp           getCreatedAt()              Returns the current record's "created_at" value
 * @method timestamp           getUpdatedAt()              Returns the current record's "updated_at" value
 * @method Doctrine_Collection getSfGuardGroupPermission() Returns the current record's "SfGuardGroupPermission" collection
 * @method Doctrine_Collection getSfGuardUserGroup()       Returns the current record's "SfGuardUserGroup" collection
 * @method SfGuardGroup        setId()                     Sets the current record's "id" value
 * @method SfGuardGroup        setName()                   Sets the current record's "name" value
 * @method SfGuardGroup        setDescription()            Sets the current record's "description" value
 * @method SfGuardGroup        setCreatedAt()              Sets the current record's "created_at" value
 * @method SfGuardGroup        setUpdatedAt()              Sets the current record's "updated_at" value
 * @method SfGuardGroup        setSfGuardGroupPermission() Sets the current record's "SfGuardGroupPermission" collection
 * @method SfGuardGroup        setSfGuardUserGroup()       Sets the current record's "SfGuardUserGroup" collection
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseSfGuardGroup extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('sf_guard_group');
        $this->hasColumn('id', 'integer', 8, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => true,
             'autoincrement' => true,
             'length' => 8,
             ));
        $this->hasColumn('name', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('description', 'string', null, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => '',
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
        $this->hasMany('SfGuardGroupPermission', array(
             'local' => 'id',
             'foreign' => 'group_id'));

        $this->hasMany('SfGuardUserGroup', array(
             'local' => 'id',
             'foreign' => 'group_id'));
    }
}