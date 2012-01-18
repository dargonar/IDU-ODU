<?php

/**
 * Parametrosensayosidu form base class.
 *
 * @method Parametrosensayosidu getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseParametrosensayosiduForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'parametrosensayosidu_id'                       => new sfWidgetFormInputHidden(),
      'parametrosensayosidu_referencia'               => new sfWidgetFormInputText(),
      'parametrosensayosidu_descripcion'              => new sfWidgetFormInputText(),
      'parametrosensayosidu_dcfs'                     => new sfWidgetFormInputText(),
      'parametrosensayosidu_modificado'               => new sfWidgetFormDateTime(),
      'parametrosensayosidu_retardostopinicial'       => new sfWidgetFormInputText(),
      'parametrosensayosidu_retardostartmitad'        => new sfWidgetFormInputText(),
      'parametrosensayosidu_timeoutcalor'             => new sfWidgetFormInputText(),
      'parametrosensayosidu_timeoutfrio'              => new sfWidgetFormInputText(),
      'parametrosensayosidu_retardostart2bajatension' => new sfWidgetFormInputText(),
      'parametrosensayosidu_tiempomodovelocidadbaja'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_tiempomodovelocidadalta'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_retardodesenergizado'     => new sfWidgetFormInputText(),
      'parametrosensayosidu_final'                    => new sfWidgetFormInputText(),
      'parametrosensayosidu_temperatura'              => new sfWidgetFormInputText(),
      'parametrosensayosidu_velocidadbajatensionmin'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_velocidadbajatensionmax'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_corrientebajatensionmin'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_corrientebajatensionmax'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_velocidadminmodovelbaja'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_velocidadmaxmodovelbaja'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_corrienteminmodovelbaja'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_corrientemaxmodovelbaja'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_velocidadminmodovelalta'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_velocidadmaxmodovelalta'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_corrienteminmodovelalta'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_corrientemaxmodovelalta'  => new sfWidgetFormInputText(),
      'parametrosensayosidu_timeoutbajatension'       => new sfWidgetFormInputText(),
      'parametrosensayosidu_idversion'                => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Versiones'), 'add_empty' => false)),
      'es_activo'                                     => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'parametrosensayosidu_id'                       => new sfValidatorChoice(array('choices' => array($this->getObject()->get('parametrosensayosidu_id')), 'empty_value' => $this->getObject()->get('parametrosensayosidu_id'), 'required' => false)),
      'parametrosensayosidu_referencia'               => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'parametrosensayosidu_descripcion'              => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'parametrosensayosidu_dcfs'                     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_modificado'               => new sfValidatorDateTime(),
      'parametrosensayosidu_retardostopinicial'       => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_retardostartmitad'        => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_timeoutcalor'             => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_timeoutfrio'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_retardostart2bajatension' => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_tiempomodovelocidadbaja'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_tiempomodovelocidadalta'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_retardodesenergizado'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_final'                    => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_temperatura'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_velocidadbajatensionmin'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_velocidadbajatensionmax'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_corrientebajatensionmin'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_corrientebajatensionmax'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_velocidadminmodovelbaja'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_velocidadmaxmodovelbaja'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_corrienteminmodovelbaja'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_corrientemaxmodovelbaja'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_velocidadminmodovelalta'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_velocidadmaxmodovelalta'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_corrienteminmodovelalta'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_corrientemaxmodovelalta'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosidu_timeoutbajatension'       => new sfValidatorInteger(),
      'parametrosensayosidu_idversion'                => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Versiones'))),
      'es_activo'                                     => new sfValidatorInteger(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('parametrosensayosidu[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Parametrosensayosidu';
  }

}
