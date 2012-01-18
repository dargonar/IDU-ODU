<?php
// Connection Component Binding
Doctrine_Manager::getInstance()->bindComponent('Etiquetas', 'doctrine');

/**
 * BaseEtiquetas
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $etiquetas_id
 * @property string $etiquetas_nombre
 * @property integer $etiquetas_esidu
 * @property integer $es_activa
 * @property integer $es_bulto
 * 
 * @method integer   getEtiquetasId()      Returns the current record's "etiquetas_id" value
 * @method string    getEtiquetasNombre()  Returns the current record's "etiquetas_nombre" value
 * @method integer   getEtiquetasEsidu()   Returns the current record's "etiquetas_esidu" value
 * @method integer   getEsActiva()         Returns the current record's "es_activa" value
 * @method integer   getEsBulto()          Returns the current record's "es_bulto" value
 * @method Etiquetas setEtiquetasId()      Sets the current record's "etiquetas_id" value
 * @method Etiquetas setEtiquetasNombre()  Sets the current record's "etiquetas_nombre" value
 * @method Etiquetas setEtiquetasEsidu()   Sets the current record's "etiquetas_esidu" value
 * @method Etiquetas setEsActiva()         Sets the current record's "es_activa" value
 * @method Etiquetas setEsBulto()          Sets the current record's "es_bulto" value
 * 
 * @package    sf_sandbox
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseEtiquetas extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('etiquetas');
        $this->hasColumn('etiquetas_id', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => true,
             'primary' => true,
             'autoincrement' => true,
             'length' => 4,
             ));
        $this->hasColumn('etiquetas_nombre', 'string', 64, array(
             'type' => 'string',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'notnull' => true,
             'autoincrement' => false,
             'length' => 64,
             ));
        $this->hasColumn('etiquetas_esidu', 'integer', 1, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '0',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 1,
             ));
        $this->hasColumn('es_activa', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '1',
             'notnull' => true,
             'autoincrement' => false,
             'length' => 4,
             ));
        $this->hasColumn('es_bulto', 'integer', 4, array(
             'type' => 'integer',
             'fixed' => 0,
             'unsigned' => false,
             'primary' => false,
             'default' => '1',
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