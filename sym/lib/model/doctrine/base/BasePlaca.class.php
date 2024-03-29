<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Placa', 'pcb');

/**
 * BasePlaca
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $id
 * @property string $nombre
 * @property string $codigo
 * @property string $descripcion
 * @property string $extra1
 * @property string $extra2
 * @property string $extra3
 * @property integer $ensayoid
 * @property integer $etiquetaid
 * @property integer $versionid
 * @property Ensayo $Ensayo
 * @property Etiqueta $Etiqueta
 * @property Version $Version
 * @property Doctrine_Collection $Resultadoensayo
 * 
 * @method integer             getId()              Returns the current record's "id" value
 * @method string              getNombre()          Returns the current record's "nombre" value
 * @method string              getCodigo()          Returns the current record's "codigo" value
 * @method string              getDescripcion()     Returns the current record's "descripcion" value
 * @method string              getExtra1()          Returns the current record's "extra1" value
 * @method string              getExtra2()          Returns the current record's "extra2" value
 * @method string              getExtra3()          Returns the current record's "extra3" value
 * @method integer             getEnsayoid()        Returns the current record's "ensayoid" value
 * @method integer             getEtiquetaid()      Returns the current record's "etiquetaid" value
 * @method integer             getVersionid()       Returns the current record's "versionid" value
 * @method Ensayo              getEnsayo()          Returns the current record's "Ensayo" value
 * @method Etiqueta            getEtiqueta()        Returns the current record's "Etiqueta" value
 * @method Version             getVersion()         Returns the current record's "Version" value
 * @method Doctrine_Collection getResultadoensayo() Returns the current record's "Resultadoensayo" collection
 * @method Placa               setId()              Sets the current record's "id" value
 * @method Placa               setNombre()          Sets the current record's "nombre" value
 * @method Placa               setCodigo()          Sets the current record's "codigo" value
 * @method Placa               setDescripcion()     Sets the current record's "descripcion" value
 * @method Placa               setExtra1()          Sets the current record's "extra1" value
 * @method Placa               setExtra2()          Sets the current record's "extra2" value
 * @method Placa               setExtra3()          Sets the current record's "extra3" value
 * @method Placa               setEnsayoid()        Sets the current record's "ensayoid" value
 * @method Placa               setEtiquetaid()      Sets the current record's "etiquetaid" value
 * @method Placa               setVersionid()       Sets the current record's "versionid" value
 * @method Placa               setEnsayo()          Sets the current record's "Ensayo" value
 * @method Placa               setEtiqueta()        Sets the current record's "Etiqueta" value
 * @method Placa               setVersion()         Sets the current record's "Version" value
 * @method Placa               setResultadoensayo() Sets the current record's "Resultadoensayo" collection
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BasePlaca extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('placa');
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
        $this->hasColumn('codigo', 'string', 128, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 128,
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
        $this->hasColumn('extra1', 'string', 128, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 128,
             ));
        $this->hasColumn('extra2', 'string', 128, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 128,
             ));
        $this->hasColumn('extra3', 'string', 128, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 128,
             ));
        $this->hasColumn('ensayoid', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('etiquetaid', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('versionid', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        $this->hasOne('Ensayo', array(
             'local' => 'ensayoid',
             'foreign' => 'id'));

        $this->hasOne('Etiqueta', array(
             'local' => 'etiquetaid',
             'foreign' => 'id'));

        $this->hasOne('Version', array(
             'local' => 'versionid',
             'foreign' => 'id'));

        $this->hasMany('Resultadoensayo', array(
             'local' => 'id',
             'foreign' => 'placaid'));
    }
}