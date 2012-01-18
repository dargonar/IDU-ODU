<?php

/**
 * Ensayosrealizadosidu form base class.
 *
 * @method Ensayosrealizadosidu getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseEnsayosrealizadosiduForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'ensayosrealizadosidu_id'                    => new sfWidgetFormInputHidden(),
      'ensayosrealizadosidu_marca'                 => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_modelo'                => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_codigo'                => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_serie'                 => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_fecha'                 => new sfWidgetFormDateTime(),
      'ensayosrealizadosidu_aprobado'              => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_dcf'                   => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_tiempoensayo'          => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_velocidadinicial'      => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_velocidadbajatension'  => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_velocidadlow'          => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_velocidadhigh'         => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_corrienteinicial'      => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_corrientebajatension'  => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_corrientelow'          => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_corrientehigh'         => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_corrientecalorinicial' => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_hipot'                 => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_fuga'                  => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_observaciones'         => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_cantidadreimpresion'   => new sfWidgetFormInputText(),
      'ensayosrealizadosidu_usuario'               => new sfWidgetFormInputText(),
      'orden_fabricacion'                          => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'ensayosrealizadosidu_id'                    => new sfValidatorChoice(array('choices' => array($this->getObject()->get('ensayosrealizadosidu_id')), 'empty_value' => $this->getObject()->get('ensayosrealizadosidu_id'), 'required' => false)),
      'ensayosrealizadosidu_marca'                 => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_modelo'                => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_codigo'                => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_serie'                 => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_fecha'                 => new sfValidatorDateTime(array('required' => false)),
      'ensayosrealizadosidu_aprobado'              => new sfValidatorInteger(array('required' => false)),
      'ensayosrealizadosidu_dcf'                   => new sfValidatorString(array('max_length' => 10, 'required' => false)),
      'ensayosrealizadosidu_tiempoensayo'          => new sfValidatorInteger(array('required' => false)),
      'ensayosrealizadosidu_velocidadinicial'      => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_velocidadbajatension'  => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_velocidadlow'          => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_velocidadhigh'         => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_corrienteinicial'      => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_corrientebajatension'  => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_corrientelow'          => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_corrientehigh'         => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_corrientecalorinicial' => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosidu_hipot'                 => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_fuga'                  => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_observaciones'         => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosidu_cantidadreimpresion'   => new sfValidatorInteger(array('required' => false)),
      'ensayosrealizadosidu_usuario'               => new sfValidatorString(array('max_length' => 45)),
      'orden_fabricacion'                          => new sfValidatorString(array('max_length' => 255, 'required' => false)),
    ));

    $this->widgetSchema->setNameFormat('ensayosrealizadosidu[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Ensayosrealizadosidu';
  }

}
