<?php

/**
 * LogIduOdu filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseLogIduOduFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'date'      => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'thread'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'context'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'level'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'logger'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'message'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'exception' => new sfWidgetFormFilterInput(),
      'dcf'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'username'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'line'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'date'      => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'thread'    => new sfValidatorPass(array('required' => false)),
      'context'   => new sfValidatorPass(array('required' => false)),
      'level'     => new sfValidatorPass(array('required' => false)),
      'logger'    => new sfValidatorPass(array('required' => false)),
      'message'   => new sfValidatorPass(array('required' => false)),
      'exception' => new sfValidatorPass(array('required' => false)),
      'dcf'       => new sfValidatorPass(array('required' => false)),
      'username'  => new sfValidatorPass(array('required' => false)),
      'line'      => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('log_idu_odu_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'LogIduOdu';
  }

  public function getFields()
  {
    return array(
      'id'        => 'Number',
      'date'      => 'Date',
      'thread'    => 'Text',
      'context'   => 'Text',
      'level'     => 'Text',
      'logger'    => 'Text',
      'message'   => 'Text',
      'exception' => 'Text',
      'dcf'       => 'Text',
      'username'  => 'Text',
      'line'      => 'Text',
    );
  }
}
