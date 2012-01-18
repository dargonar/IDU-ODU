<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('LogIduOdu', 'doctrine');

/**
 * BaseLogIduOdu
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property timestamp $date
 * @property string $thread
 * @property string $context
 * @property string $level
 * @property string $logger
 * @property string $message
 * @property string $exception
 * @property string $dcf
 * @property string $username
 * @property string $line
 * 
 * @method integer   getId()        Returns the current record's "id" value
 * @method timestamp getDate()      Returns the current record's "date" value
 * @method string    getThread()    Returns the current record's "thread" value
 * @method string    getContext()   Returns the current record's "context" value
 * @method string    getLevel()     Returns the current record's "level" value
 * @method string    getLogger()    Returns the current record's "logger" value
 * @method string    getMessage()   Returns the current record's "message" value
 * @method string    getException() Returns the current record's "exception" value
 * @method string    getDcf()       Returns the current record's "dcf" value
 * @method string    getUsername()  Returns the current record's "username" value
 * @method string    getLine()      Returns the current record's "line" value
 * @method LogIduOdu setId()        Sets the current record's "id" value
 * @method LogIduOdu setDate()      Sets the current record's "date" value
 * @method LogIduOdu setThread()    Sets the current record's "thread" value
 * @method LogIduOdu setContext()   Sets the current record's "context" value
 * @method LogIduOdu setLevel()     Sets the current record's "level" value
 * @method LogIduOdu setLogger()    Sets the current record's "logger" value
 * @method LogIduOdu setMessage()   Sets the current record's "message" value
 * @method LogIduOdu setException() Sets the current record's "exception" value
 * @method LogIduOdu setDcf()       Sets the current record's "dcf" value
 * @method LogIduOdu setUsername()  Sets the current record's "username" value
 * @method LogIduOdu setLine()      Sets the current record's "line" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseLogIduOdu extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('log_idu_odu');
        $this->hasColumn('id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('date', 'timestamp', 25, array(
             'type' => 'timestamp',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 25,
             ));
        $this->hasColumn('thread', 'string', 32, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 32,
             ));
        $this->hasColumn('context', 'string', 512, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 512,
             ));
        $this->hasColumn('level', 'string', 512, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 512,
             ));
        $this->hasColumn('logger', 'string', 512, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 512,
             ));
        $this->hasColumn('message', 'string', 4000, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4000,
             ));
        $this->hasColumn('exception', 'string', 2000, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => false,
             'autoincrement' => false,
             'length' => 2000,
             ));
        $this->hasColumn('dcf', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('username', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 255,
             ));
        $this->hasColumn('line', 'string', 255, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 255,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        
    }
}