<?php

/**
 * LogIduOdu form base class.
 *
 * @method LogIduOdu getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseLogIduOduForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'        => new sfWidgetFormInputHidden(),
      'date'      => new sfWidgetFormDateTime(),
      'thread'    => new sfWidgetFormInputText(),
      'context'   => new sfWidgetFormTextarea(),
      'level'     => new sfWidgetFormTextarea(),
      'logger'    => new sfWidgetFormTextarea(),
      'message'   => new sfWidgetFormTextarea(),
      'exception' => new sfWidgetFormTextarea(),
      'dcf'       => new sfWidgetFormInputText(),
      'username'  => new sfWidgetFormInputText(),
      'line'      => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'        => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'date'      => new sfValidatorDateTime(),
      'thread'    => new sfValidatorString(array('max_length' => 32)),
      'context'   => new sfValidatorString(array('max_length' => 512)),
      'level'     => new sfValidatorString(array('max_length' => 512)),
      'logger'    => new sfValidatorString(array('max_length' => 512)),
      'message'   => new sfValidatorString(array('max_length' => 4000)),
      'exception' => new sfValidatorString(array('max_length' => 2000, 'required' => false)),
      'dcf'       => new sfValidatorString(array('max_length' => 255)),
      'username'  => new sfValidatorString(array('max_length' => 255)),
      'line'      => new sfValidatorString(array('max_length' => 255)),
    ));

    $this->widgetSchema->setNameFormat('log_idu_odu[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'LogIduOdu';
  }

}
