<?php

/**
 * Infoensayosreset filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseInfoensayosresetFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'fecha'           => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'numeroensayosok' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'usuario'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'pc'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'esidu'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'fecha'           => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'numeroensayosok' => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'usuario'         => new sfValidatorPass(array('required' => false)),
      'pc'              => new sfValidatorPass(array('required' => false)),
      'esidu'           => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('infoensayosreset_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Infoensayosreset';
  }

  public function getFields()
  {
    return array(
      'id'              => 'Number',
      'fecha'           => 'Date',
      'numeroensayosok' => 'Number',
      'usuario'         => 'Text',
      'pc'              => 'Text',
      'esidu'           => 'Text',
    );
  }
}
